﻿using System;
using System.Collections.Generic;
using System.Linq;
using SwinGameSDK;
using Template.Utilities;
using TiledSharp;

namespace Template.Entities
{
    public class TileMap : Entity
    {
        private Bitmap _bitmap;
        private TmxMap _map;

        public TileMap(string tmxPath)
        {
            _map = new TmxMap(tmxPath);

            _bitmap = SwinGame.CreateBitmap(_map.Width * _map.TileWidth, _map.Height * _map.TileHeight);
            SwinGame.ClearSurface(_bitmap, Color.Cyan);

            Dictionary<TmxTileset, Bitmap> tilesetBitmaps = LoadTilesetBitmaps(_map);
            DrawLayersToBitmap(_map, tilesetBitmaps);

            FreeTilesetBitmaps(tilesetBitmaps);
        }

        public override void OnUpdate(EntityManager entityManager)
        {
            SwinGame.DrawBitmap(_bitmap, 0, 0);
        }

        public bool CheckCollision(Vector2 position)
        {
            Vector2 tilePosition = new Vector2
            {
                X = (int) (position.X / 32.0f),
                Y = (int) (position.Y / 32.0f)
            };

            if (tilePosition.X < 0 || tilePosition.X >= _map.Width || tilePosition.Y < 0 ||
                tilePosition.Y >= _map.Height) return false;

            return _map.TileLayers[0].Tiles[(int) (tilePosition.Y * _map.Width + tilePosition.X)].Gid == 1;
        }

        public void Free()
        {
            SwinGame.FreeBitmap(_bitmap);
        }

        private Dictionary<TmxTileset, Bitmap> LoadTilesetBitmaps(TmxMap map)
        {
            Dictionary<TmxTileset, Bitmap> tilesetBitmaps = new Dictionary<TmxTileset, Bitmap>();

            foreach (TmxTileset tileset in map.Tilesets)
            {
                Bitmap bitmap = SwinGame.LoadBitmap(tileset.Image.Source);
                tilesetBitmaps.Add(tileset, bitmap);
            }

            return tilesetBitmaps;
        }

        private void DrawLayersToBitmap(TmxMap map, Dictionary<TmxTileset, Bitmap> tilesetBitmaps)
        {
            foreach (TmxLayer layer in map.TileLayers)
            {
                foreach (TmxLayerTile tile in layer.Tiles)
                {
                    if (tile.Gid == 0) continue;

                    int gidOffset = map.Tilesets.Aggregate(1,
                        (offset, next) => next.FirstGid <= tile.Gid ? offset + next.FirstGid - 1 : offset);
                    TmxTileset tileset = map.Tilesets.Aggregate(map.Tilesets[0],
                        (current, next) => next.FirstGid <= tile.Gid ? next : current);

                    Bitmap bitmap = tilesetBitmaps[tileset];

                    int tileIndex = tile.Gid - gidOffset;
                    float tilesetWidth = tileset.Image.Width.Value / (float) map.TileWidth;

                    Rectangle rectangle = new Rectangle
                    {
                        X = map.TileWidth * (tileIndex % tilesetWidth),
                        Y = map.TileHeight * (int) Math.Floor(tileIndex / tilesetWidth),
                        Width = map.TileWidth,
                        Height = map.TileHeight
                    };

                    SwinGame.DrawBitmapPart(_bitmap, bitmap, rectangle, tile.X * map.TileWidth,
                        tile.Y * map.TileHeight);
                }
            }
        }

        private void FreeTilesetBitmaps(Dictionary<TmxTileset, Bitmap> tilesetBitmaps)
        {
            foreach (KeyValuePair<TmxTileset, Bitmap> tilesetBitmap in tilesetBitmaps)
            {
                SwinGame.FreeBitmap(tilesetBitmap.Value);
            }
        }
    }
}
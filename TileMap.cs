using System;
using System.Collections.Generic;
using System.Linq;
using SwinGameSDK;
using TiledSharp;

namespace Template
{
    public class TileMap
    {
        private Bitmap _bitmap;

        public TileMap(string tmxPath)
        {
            TmxMap map = new TmxMap(tmxPath);

            _bitmap = SwinGame.CreateBitmap(map.Width * map.TileWidth, map.Height * map.TileHeight);
            SwinGame.ClearSurface(_bitmap, Color.Cyan);

            Dictionary<TmxTileset, Bitmap> tilesetBitmaps = LoadTilesetBitmaps(map);
            DrawLayersToBitmap(map, tilesetBitmaps);

            FreeTilesetBitmaps(tilesetBitmaps);
        }

        public void Draw()
        {
            SwinGame.DrawBitmap(_bitmap, 0, 0);
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
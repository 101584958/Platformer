using System;
using System.Collections.Generic;
using System.Linq;
using SwinGameSDK;
using Template.Utilities;
using TiledSharp;

namespace Template.Entities
{
    public class TileMap : Entity
    {
        public override int ZIndex => -1;

        private Bitmap _bitmap;
        private TmxMap _map;

        public TileMap(string tmxPath, EntityManager entityManager)
        {
            _map = new TmxMap(tmxPath);

            _bitmap = SwinGame.CreateBitmap(_map.Width * _map.TileWidth, _map.Height * _map.TileHeight);
            SwinGame.ClearSurface(_bitmap, Color.Cyan);

            Dictionary<TmxTileset, Bitmap> tilesetBitmaps = LoadTilesetBitmaps(_map);
            DrawLayersToBitmap(_map, tilesetBitmaps);

            FreeTilesetBitmaps(tilesetBitmaps);

            LoadEntities(entityManager);
        }

        public override void OnUpdate(EntityManager entityManager)
        {

        }

        public override void OnRender(EntityManager entityManager)
        {
            SwinGame.DrawBitmap(_bitmap, 0, 0);
        }

        public void LoadEntities(EntityManager entityManager)
        {
            for (int y = 0; y < _map.Height; y++)
            {
                for (int x = 0; x < _map.Width; x++)
                {
                    if (_map.TileLayers[0].Tiles[y * _map.Width + x].Gid == 1 || _map.TileLayers[0].Tiles[y * _map.Width + x].Gid == 3)
                    {
                        Vector2 tilePosition = new Vector2(x * _map.TileWidth, y * _map.TileHeight);
                        Vector2 tileSize = new Vector2(_map.TileWidth, _map.TileHeight);

                        entityManager.AddEntity(new Collider(tilePosition, tileSize));
                    }
                }
            }

            foreach (TmxObject tmxObject in _map.ObjectGroups[0].Objects)
            {
                AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes()).Where(type => type.Name == tmxObject.Type).Where(type => typeof(Entity).IsAssignableFrom(type)).Where(type => type.GetConstructor(new[] { typeof(TmxObject), typeof(TmxMap) }) != null).Select(type => Activator.CreateInstance(type, new object[] { tmxObject, _map })).ToList().ForEach(entity => entityManager.AddEntity(entity as Entity));
            }
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

                    int gidOffset = map.Tilesets.Aggregate(1, (offset, next) => next.FirstGid <= tile.Gid ? offset + next.FirstGid - 1 : offset);
                    TmxTileset tileset = map.Tilesets.Aggregate(map.Tilesets[0], (current, next) => next.FirstGid <= tile.Gid ? next : current);

                    Bitmap bitmap = tilesetBitmaps[tileset];

                    int tileIndex = tile.Gid - gidOffset;
                    float tilesetWidth = tileset.Image.Width.Value / (float)map.TileWidth;

                    Rectangle rectangle = new Rectangle
                    {
                        X = map.TileWidth * (tileIndex % tilesetWidth),
                        Y = map.TileHeight * (int)Math.Floor(tileIndex / tilesetWidth),
                        Width = map.TileWidth,
                        Height = map.TileHeight
                    };

                    SwinGame.DrawBitmapPart(_bitmap, bitmap, rectangle, tile.X * map.TileWidth, tile.Y * map.TileHeight);
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
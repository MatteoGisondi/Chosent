using Godot;
using System;

public class Grid : Node2D {
    int[,] grid;
    TileMap tilemap;

    public override void _Ready() {
        grid = new int[10,10];

        tilemap = new TileMap();
        AddChild(tilemap);

        // Set the tilemap size to match the grid size
        tilemap.CellSize = new Vector2(32, 32);
        tilemap.SetSize(grid.GetLength(0), grid.GetLength(1));

        var tile_set = new TileSet();
        tile_set.CreateTileSet(new Vector2(32, 32));
        tilemap.TileSet = tile_set;

        for (int i = 0; i < grid.GetLength(0); i++) {
            for (int j = 0; j < grid.GetLength(1); j++) {
                int tile_id = grid[i, j];
                tilemap.SetCell(i, j, tile_id);
            }
        }
    }
}


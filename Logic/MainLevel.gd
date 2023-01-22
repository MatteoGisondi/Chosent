extends Node2D

var color = Color8(75,75,75,255)
var screen_size = OS.window_size
var texture = load("res://assets/Floor.png")
var texture_size = texture.get_size()

func _draw():
	tile_draw(texture_size.x,texture_size.y)
	draw_grid(64,64,color)

func draw_grid(SizeX, SizeY, LineColor):
	for x in range(0,64*8,SizeX):
		draw_line(Vector2(x,0),Vector2(x,screen_size.y),LineColor,1.5)
	for y in range(0,64*8,SizeY):
		draw_line(Vector2(0,y),Vector2(screen_size.x,y),LineColor,1.5)

func tile_draw(SizeX, SizeY):
	for x in range(0,64*8,SizeX):
		for y in range(0,64*8,SizeY):
			draw_texture(texture, Vector2(x,y))

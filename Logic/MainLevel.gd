extends Node2D

var color = Color(0,0,0)
var screen_size = OS.window_size
func _draw():
	draw_grid(64,64,color)
func draw_grid(SizeX, SizeY, LineColor):
	for x in range(0,screen_size.x,SizeX):
		draw_line(Vector2(x,0),Vector2(x,screen_size.y),LineColor,1)
	for y in range(0,screen_size.y,SizeY):
		draw_line(Vector2(0,y),Vector2(screen_size.x,y),LineColor,1)

Character = {
	-- Permite a criação de personagens.
	Creation = true,

	-- Permite a exclusão de personagens.
	Delete = true,

	-- Leve mínimo para exclusão.
	DeleteMinLevel = 1,

	-- Level máximo para exclusão.
	DeleteMaxLevel = 50,	
}

--Level Min, Level Max, Tempo em minutos
AddDeleteTime(1, 9, 2)
AddDeleteTime(10, 19, 3)
AddDeleteTime(20, 29, 4)
AddDeleteTime(30, 39, 5)
AddDeleteTime(40, 49, 6)
AddDeleteTime(50, 59, 7)
AddDeleteTime(60, 69, 8)
AddDeleteTime(70, 79, 9)
AddDeleteTime(80, 89, 10)
AddDeleteTime(90, 99, 11)
AddDeleteTime(100, 150, 15)
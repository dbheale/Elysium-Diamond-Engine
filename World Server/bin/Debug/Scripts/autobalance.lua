
Enabled = false

-- ID de região, GameServerID, Nome do Canal, Externo IP, LocalIP, GamePort, Capacidade, Porcentagem limite
-- Mapa inicial
-- Exemplo de configuração, adiciona 2 canais para cada mapa (gameserver).
-- Cada mapa fica em um servidor diferente, aumentando o número de usuários.
-- Se a quantidade de jogadores, exceder 60% do total, o próximo canal será usado.
AddChannel(1, -3, "Mapa 1 Canal 1", "127.0.0.1", "127.0.0.1", 55970, 2000, 60);
AddChannel(1, -4, "Mapa 1 Canal 2", "127.0.0.1", "127.0.0.1", 55971, 2000, 60);

-- Calderock Village
AddChannel(2, -5, "Calderock Village Canal 1", "127.0.0.1", "127.0.0.1", 55972, 2000, 60);
AddChannel(2, -6, "Calderock Village Canal 2", "127.0.0.1", "127.0.0.1", 55973, 2000, 60);
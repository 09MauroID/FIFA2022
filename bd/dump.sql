CALL altaUsuario (1, 'LuciaMijal22', 12345678, 'Mujica', 'Ceballos', 1000);
CALL altaUsuario (5, 'IsmaJoel25', 12345679, 'Guemes', 'Rosarino', 1000);
CALL altaPosicion (3, 'Defensa');
CALL altaHabilidad (4, 'Muralla', 'Ultima defensa');
CALL altaFutbolista (1, 2, 3, 4, 'Carlos', 'Zantana', '1996-04-09', 70, 90, 60, 99);
CALL altaPropietario (1, 2);
CALL altaSkill (4,2);
CALL Publicar (1, 2, 100,'2022-05-26 10:56:36');
CALL Comprar (1, 5, 2, '2022-05-26 10:56:36');
CALL TransferenciasActivas (2);
SELECT gananciasEntre (2, '2022-04-25 10:56:36', '2022-06-20 10:56:36', NOW());



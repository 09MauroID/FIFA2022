-- Active: 1646654372192@@127.0.0.1@3306@fifa

SELECT 'Dump' Estado;

CALL
    altaUsuario (
        @idLuciaMijal22,
        'LuciaMijal22',
        12345678,
        'Mujica',
        'Ceballos',
        1000
    );

CALL
    altaUsuario (
        @idIsmaJoel25,
        'IsmaJoel25',
        12345679,
        'Guemes',
        'Rosarino',
        1000
    );

CALL altaPosicion (@Posicion1, 'Defensa');

CALL altaPosicion (@Posicion2, 'Delantero');

CALL altaHabilidad (@Habilidad1, 'Muralla', 'Ultima defensa');

SELECT @Posicion1;

CALL
    altaFutbolista (
        @Futbolista1,
        -- idFutbolista
        @Posicion1,
        -- idPosicion 
        'Carlos',
        -- Nombre
        'Zantana',
        -- Apellido
        '1996-04-09',
        -- Nacimiento
        70,
        -- Velocidad
        90,
        -- Remate
        60,
        -- Pase
        99 -- Defensa
    );

SELECT @Posicion2;

CALL
    altaFutbolista (
        @Futbolista2,
        @Posicion2,
        'Leo',
        'Messi',
        '1987-06-24',
        100,
        100,
        100,
        100
    );
SELECT @Futbolista2;
CALL altaPropietario (@idLuciaMijal22, @Futbolista1);

CALL altaSkill (@Habilidad1, @Futbolista1);

CALL Publicar (@idLuciaMijal22, @Futbolista1, 100,'2022-05-26 10:56:36');

CALL Comprar (@idLuciaMijal22, @idIsmaJoel25, @Futbolista1, '2022-05-26 10:56:36');

CALL TransferenciasActivas (@Futbolista1);

SELECT
    gananciasEntre (
        @Futbolista1,
        '2022-04-25 10:56:36',
        '2022-06-20 10:56:36',
        NOW()
    );

-- Ejemplos para romper y probar triggers

CALL Publicar (@idLuciaMijal22, @Futbolista1, 10000, '2022-08-04 14:52:23');
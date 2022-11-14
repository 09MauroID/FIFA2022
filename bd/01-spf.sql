USE Fifa;

SELECT 'Creando SPF' Estado;

-- PUNTO 1

DELIMITER $$

DROP PROCEDURE
    IF EXISTS altaPropietario $$
CREATE PROCEDURE
    altaPropietario (
        unIdUsuario INT,
        unIdFutbolista INT
    ) BEGIN
INSERT INTO
    Propietario (idUsuario, idFutbolista)
VALUES (unIdUsuario, unIdFutbolista);

END $$ 

DELIMITER $$

DROP PROCEDURE
    IF EXISTS altaPosicion $$
CREATE PROCEDURE
    altaPosicion (
        OUT unIdPosicion TINYINT UNSIGNED,
        unNombre VARCHAR(45)
    ) BEGIN
INSERT INTO
    Posicion (idPosicion, nombre)
VALUES (unIdPosicion, unNombre);

set unIdPosicion= LAST_INSERT_ID();

END $$ 

DELIMITER $$

DROP PROCEDURE
    IF EXISTS altaSkill $$
CREATE PROCEDURE
    altaSkill (
        unIdHabilidad TINYINT UNSIGNED,
        unIdFutbolista INT
    ) BEGIN
INSERT INTO
    Skill (idHabilidad, idFutbolista)
VALUES (unIdHabilidad, unIdFutbolista);

END $$ 

DELIMITER $$

DROP PROCEDURE
    IF EXISTS altaUsuario $$
CREATE PROCEDURE
    altaUsuario (
        out unIdUsuario INT,
        unUser VARCHAR(15),
        unaContrasena CHAR(64),
        unNombre VARCHAR(45),
        unApellido VARCHAR(45),
        unaMonedas MEDIUMINT UNSIGNED
    ) BEGIN
INSERT INTO
    Usuario (
        idUsuario,
        User,
        Contrasena,
        Nombre,
        Apellido,
        Monedas
    )
VALUES (
        unIdUsuario,
        unUser,
        unaContrasena,
        unNombre,
        unApellido,
        unaMonedas
    );

set unIdUsuario = LAST_INSERT_ID();

END $$ 

DELIMITER $$

DROP PROCEDURE
    IF EXISTS altaFutbolista $$
CREATE PROCEDURE
    altaFutbolista (
        unIdFutbolista INT,
        unIdPosicion TINYINT UNSIGNED,
        unNombre VARCHAR(45),
        unApellido VARCHAR(45),
        unNacimiento DATE,
        unaVelocidad TINYINT UNSIGNED,
        unRemate TINYINT UNSIGNED,
        unPase TINYINT UNSIGNED,
        unaDefensa TINYINT UNSIGNED
    ) BEGIN
INSERT INTO
    Futbolista (
        idFutbolista,
        idPosicion,
        Nombre,
        Apellido,
        Nacimiento,
        Velocidad,
        Remate,
        Pase,
        Defensa
    )
VALUES (
        unIdFutbolista,
        unIdPosicion,
        unNombre,
        unApellido,
        unNacimiento,
        unaVelocidad,
        unRemate,
        unPase,
        unaDefensa
    );

END $$ 

DELIMITER $$

DROP PROCEDURE
    IF EXISTS altaHabilidad $$
CREATE PROCEDURE
    altaHabilidad (
        unIdHabilidad TINYINT UNSIGNED,
        unNombre VARCHAR(45),
        unaDescripcion VARCHAR(45)
    ) BEGIN
INSERT INTO
    Habilidad (
        idHabilidad,
        Nombre,
        Descripcion
    )
VALUES (
        unIdHabilidad,
        unNombre,
        unaDescripcion
    );

END $$ # Nuevo SP Usuario
DROP PROCEDURE
    IF EXISTS UsuarioPorIdUsuario $$
CREATE PROCEDURE
    UsuarioPorIdUsuario(unIdUsuario INT) BEGIN
SELECT *
FROM Usuario
WHERE idUsuario = unIdUsuario;

END $$ # Nuevo SP Futbolista
DROP PROCEDURE
    IF EXISTS FutbolistaPorIdFutbolista $$
CREATE PROCEDURE
    FutbolistaPorIdFutbolista(unIdFutbolista INT) BEGIN
SELECT *
FROM Futbolista
WHERE
    idFutbolista = unIdFutbolista;

END $$
DROP PROCEDURE
    IF EXISTS PosicionPorIdPosicion $$
CREATE PROCEDURE
    PosicionPorIdPosicion(unIdPosicion TINYINT UNSIGNED) BEGIN
SELECT *
FROM Posicion
WHERE idPosicion = unIdPosicion;

END $$
DROP PROCEDURE
    IF EXISTS HabilidadPorIdHabilidad $$
CREATE PROCEDURE
    HabilidadPorIdHabilidad(unIdHabilidad TINYINT UNSIGNED) BEGIN
SELECT *
FROM Habilidad
WHERE
    idHabilidad = unIdHabilidad;

END $$ -- PUNTO 2

DELIMITER $$

DROP PROCEDURE
    IF EXISTS Publicar $$
CREATE PROCEDURE
    Publicar(
        unIdVendedor INT,
        unIdFutbolista INT,
        unPrecioMonedas MEDIUMINT UNSIGNED,
        unaPublicacion DATETIME
    ) BEGIN
INSERT INTO
    Transferencia (
        idVendedor,
        idComprador,
        Publicacion,
        Confirmacion,
        idFutbolista,
        PrecioMonedas
    )
VALUES (
        unIdVendedor,
        NULL,
        unaPublicacion,
        NULL,
        unIdFutbolista,
        unPrecioMonedas
    );

END $$ 

DELIMITER $$

DROP PROCEDURE
    IF EXISTS Comprar $$
CREATE PROCEDURE
    Comprar (
        unIdVendedor INT,
        unIdComprador INT,
        unIdFutbolista INT,
        unaPublicacion DATETIME
    ) BEGIN DECLARE varMonedas MEDIUMINT UNSIGNED;

SELECT
    PrecioMonedas INTO varMonedas
FROM Transferencia
WHERE
    idFutbolista = unidFutbolista
    AND IdVendedor = unIdVendedor;

UPDATE Transferencia
SET
    idComprador = unIdComprador,
    Confirmacion = NOW()
WHERE
    idFutbolista = unidFutbolista
    AND idVendedor = unIdVendedor
    AND Publicacion = unaPublicacion;

UPDATE Propietario
SET idUsuario = unidComprador
WHERE
    idFutbolista = unIdFutbolista
    AND idUsuario = unIdVendedor;

UPDATE Usuario
SET
    Monedas = Monedas + varMonedas
WHERE idUsuario = unIdVendedor;

UPDATE Usuario
SET
    Monedas = Monedas - varMonedas
WHERE idUsuario = unidComprador;

END $$ -- PUNTO 3

DELIMITER $$

DROP PROCEDURE
    IF EXISTS TransferenciasActivas $$
CREATE PROCEDURE
    TransferenciasActivas (unidFutbolista INT) BEGIN
SELECT *
FROM Transferencia
WHERE
    Confirmacion IS NULL
    AND idFutbolista = unidFutbolista;

END $$ -- PUNTO 4

DELIMITER $$

DROP FUNCTION
    IF EXISTS gananciasEntre $$
CREATE FUNCTION
    gananciasEntre (
        unIdFutbolista INT,
        Inicio DATETIME,
        Fin DATETIME,
        Confirmacion DATETIME
    ) RETURNS MEDIUMINT UNSIGNED READS SQL DATA BEGIN DECLARE sumatoria MEDIUMINT UNSIGNED;

SELECT
    SUM(PrecioMonedas) INTO sumatoria
FROM Transferencia
WHERE
    idFutbolista = unIdFutbolista
    AND Confirmacion BETWEEN Inicio AND Fin;

RETURN sumatoria;

END $$ 

DELIMITER $$

DROP FUNCTION
    IF EXISTS posesionUsuario $$
CREATE FUNCTION
    posesionUsuario (
        unIdUsuario INT,
        unIdFutbolista INT
    ) RETURNS BOOL READS SQL DATA BEGIN IF (
        EXISTS (
            SELECT *
            FROM Propietario
            WHERE
                idUsuario = unIdUsuario
                AND idFutbolista = unIdFutbolista
        )
    ) THEN
RETURN TRUE;

END IF;

RETURN FALSE;

END$$ 
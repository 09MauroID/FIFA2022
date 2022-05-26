USE Fifa;

-- PUNTO 1
DELIMITER $$
DROP PROCEDURE IF EXISTS altaPropietario $$
CREATE PROCEDURE altaPropietario (unIdUsuario INT, unIdFutbolista INT)
BEGIN
    INSERT INTO Propietario (idUsuario, idFutbolista)
        VALUES (unIdUsuario, unIdFutbolista);
END $$

DELIMITER $$
DROP PROCEDURE IF EXISTS altaPosicion $$
CREATE PROCEDURE altaPosicion (unIdPosicion INT, unNombre VARCHAR(45))
BEGIN
    INSERT INTO Posicion (idPosicion, nombre)
        VALUES (unIdPosicion, unNombre);
END $$

DELIMITER $$
DROP PROCEDURE IF EXISTS altaSkill $$
CREATE PROCEDURE altaSkill (unIdHabilidad INT, unIdFutbolista INT)
BEGIN
    INSERT INTO Skill (idHabilidad, idFutbolista)
        VALUES (unIdHabilidad, unIdFutbolista);
END $$

DELIMITER $$
DROP PROCEDURE IF EXISTS altaUsuario $$
CREATE PROCEDURE altaUsuario (unIdUsuario INT, unUser VARCHAR(15), unaContrasena CHAR(64), unNombre VARCHAR(45), unApellido VARCHAR(45), unaMonedas MEDIUMINT UNSIGNED)
BEGIN
    INSERT INTO Usuario (idUsuario, User, Contrasena, Nombre, Apellido, Monedas)
        VALUES (unIdUsuario, unUser, unaContrasena, unNombre, unApellido, unaMonedas);
END $$

DELIMITER $$
DROP PROCEDURE IF EXISTS altaFutbolista $$
CREATE PROCEDURE altaFutbolista (unIdUsuario INT, unIdFutbolista INT, unIdPosicion INT, unIdHabilidad INT, unNombre VARCHAR(45), unApellido VARCHAR(45), unNacimiento DATE, unaVelocidad TINYINT UNSIGNED, unRemate TINYINT UNSIGNED, unPase TINYINT UNSIGNED, unaDefensa TINYINT UNSIGNED)
BEGIN
	INSERT INTO Futbolista (idUsuario, idFutbolista, idPosicion, idHabilidad, Nombre, Apellido, Nacimiento, Velocidad, Remate, Pase, Defensa)
		VALUES (unIdUsuario, unIdFutbolista, unIdPosicion, unIdHabilidad, unNombre, unApellido, unNacimiento, unaVelocidad, unRemate, unPase,unaDefensa);
END $$

DELIMITER $$
DROP PROCEDURE IF EXISTS altaHabilidad $$
CREATE PROCEDURE altaHabilidad (unIdHabilidad INT, unNombre VARCHAR(45), unaDescripcion VARCHAR(45))
BEGIN
	INSERT INTO Habilidad (idHabilidad, Nombre, Descripcion)
		VALUES (unIdHabilidad, unNombre, unaDescripcion);
END $$


-- PUNTO 2
DELIMITER $$
DROP PROCEDURE IF EXISTS Publicar $$
CREATE PROCEDURE Publicar(unIdVendedor INT, unIdFutbolista INT, unPrecioMonedas MEDIUMINT UNSIGNED, unaPublicacion DATETIME)
BEGIN
	INSERT INTO Transferencia (idVendedor, idComprador, Publicacion, Confirmacion, idFutbolista, PrecioMonedas)
		VALUES(unIdVendedor, NULL, unaPublicacion, NULL, unIdFutbolista, unPrecioMonedas);
END $$

DELIMITER $$
DROP PROCEDURE IF EXISTS Comprar $$
CREATE PROCEDURE Comprar (unIdVendedor INT, unIdComprador INT, unIdFutbolista INT, unaPublicacion DATETIME)
BEGIN
	DECLARE varMonedas MEDIUMINT UNSIGNED;
    
    SELECT PrecioMonedas INTO varMonedas
    FROM Transferencia
    WHERE idFutbolista = unidFutbolista
    AND IdVendedor = unIdVendedor;
    
	UPDATE Transferencia
    SET idComprador = unIdComprador,
	Confirmacion = NOW()
    WHERE idFutbolista = unidFutbolista
    AND idVendedor = unIdVendedor
    AND Publicacion = unaPublicacion;

    UPDATE Propietario
    SET idUsuario = unidComprador
    WHERE idFutbolista = unIdFutbolista
	AND idUsuario = unIdVendedor;

    UPDATE Usuario
    SET Monedas = Monedas + varMonedas
    WHERE idUsuario = unIdVendedor;
    
    UPDATE Usuario
    SET Monedas = Monedas - varMonedas
    WHERE idUsuario = unidComprador;

END $$


-- PUNTO 3
DELIMITER $$
DROP PROCEDURE IF EXISTS TransferenciasActivas $$
CREATE PROCEDURE TransferenciasActivas (unidFutbolista INT)
BEGIN
SELECT *
FROM Transferencia
WHERE Confirmacion = NULL
AND idFutbolista = unidFutbolista;
END $$


-- PUNTO 4
DELIMITER $$
DROP FUNCTION IF EXISTS gananciasEntre $$
CREATE FUNCTION gananciasEntre (unIdFutbolista INT, Inicio DATETIME, Fin DATETIME, Confirmacion DATETIME) RETURNS MEDIUMINT UNSIGNED
READS SQL DATA
BEGIN
    DECLARE sumatoria MEDIUMINT UNSIGNED;

    SELECT  SUM(PrecioMonedas)  INTO sumatoria
    FROM    Transferencia
    WHERE   idFutbolista = unIdFutbolista
    AND     Confirmacion BETWEEN Inicio AND Fin;

    RETURN  sumatoria;
END $$
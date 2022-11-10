use Fifa;
SELECT 'Creando Triggers' Estado;
DELIMITER $$
DROP TRIGGER IF EXISTS befInsFila $$
CREATE TRIGGER befInsFila BEFORE INSERT ON Transferencia FOR EACH ROW
BEGIN
	IF (NOT posesionUsuario(NEW.idVendedor ,NEW.idFutbolista)) THEN
		SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'El usuario no posee al futbolista';
	END IF;
END$$

DELIMITER $$
DROP TRIGGER IF EXISTS befInsCom $$
CREATE TRIGGER befInsCom BEFORE INSERT ON Transferencia FOR EACH ROW
BEGIN
    IF (EXISTS (SELECT *
            FROM Usuario
            WHERE idUsuario = NEW.idComprador
            AND Monedas < PrecioMonedas)) THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Monedas insuficientes';
    END IF;

    IF (posesionUsuario(NEW.idComprador, NEW.idFutbolista)) THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Jugador en posesión';
    END IF;
END$$


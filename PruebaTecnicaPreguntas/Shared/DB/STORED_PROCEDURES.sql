
CREATE PROCEDURE BuscarPreguntaPorId
	@Id INT
AS
BEGIN
	SELECT 
			Pregunta.Id, Pregunta.Pregunta, Pregunta.Likes, Pregunta.IdEstado,Pregunta.IdUsuario, 
			Estado.NombreEstado, 
			Usuario.NombreUsuario

	FROM Pregunta

	INNER JOIN Estado ON Pregunta.IdEstado = Estado.Id
	INNER JOIN Usuario ON Pregunta.IdUsuario = Usuario.Id 

	WHERE Pregunta.Id = @Id
	
	RETURN

END
GO




ALTER PROCEDURE ObtenerPreguntas

AS
BEGIN
	SELECT 
			Pregunta.Id, Pregunta.Pregunta, Pregunta.Likes, Pregunta.IdEstado,Pregunta.IdUsuario, 
			Estado.NombreEstado, 
			Usuario.NombreUsuario 
	FROM Pregunta

	INNER JOIN Estado ON Pregunta.IdEstado = Estado.Id
	INNER JOIN Usuario ON Pregunta.IdUsuario = Usuario.Id
	 
	
	ORDER BY Pregunta.Id DESC
RETURN
END
GO




CREATE PROCEDURE AgregarPregunta 
	@Pregunta VARCHAR(200),
	@IdUsuario INT
	
AS
BEGIN
	DECLARE @LastId INT

	INSERT INTO Pregunta (Pregunta,IdUsuario,IdEstado,Likes) VALUES (@Pregunta,@IdUsuario,1,0);

	SELECT @LastId = CONVERT(INT,SCOPE_IDENTITY());
	
	EXEC BuscarPreguntaPorId @Id = @LastId;
			
	RETURN
END
GO


ALTER PROCEDURE ObtenerRespuestasPopulares
	@IdPregunta INT
AS
BEGIN

	SELECT TOP 5
	Respuesta.Id,Respuesta.Respuesta,Respuesta.IdPregunta,Respuesta.Likes,Respuesta.IdUsuario,
	Usuario.NombreUsuario
	
	FROM Respuesta

	INNER JOIN Usuario ON Respuesta.IdUsuario = Usuario.Id

	WHERE IdPregunta = @IdPregunta

	ORDER BY Likes DESC 
RETURN
END
GO

EXEC ObtenerRespuestasPopulares 1

CREATE PROCEDURE BuscarRespuestaPorId
	
	@Id INT

AS
BEGIN

	SELECT Id,Respuesta,IdPregunta,Likes
	
	FROM Respuesta

	WHERE Id = @Id


RETURN
END
GO





CREATE PROCEDURE Responder 
	@Respuesta VARCHAR(200),
	@IdPregunta INT,
	@IdUsuario INT
AS
BEGIN
	DECLARE @LastRespuesta INT

	INSERT INTO Respuesta (IdPregunta,Respuesta,Likes,IdUsuario) VALUES(@IdPregunta,@Respuesta,0,@IdUsuario);
	SELECT @LastRespuesta = CONVERT(INT,SCOPE_IDENTITY());

	EXEC BuscarRespuestaPorId @Id = @LastRespuesta;

RETURN
END
GO




CREATE PROCEDURE ObtenerRespuestas 
	@IdPregunta INT
AS 
BEGIN

	SELECT 
	Respuesta.Id,Respuesta.Respuesta,Respuesta.IdPregunta,Respuesta.Likes,Respuesta.IdUsuario,
	Usuario.NombreUsuario
	
	FROM Respuesta

	INNER JOIN Usuario ON Respuesta.IdUsuario = Usuario.Id

	WHERE IdPregunta = @IdPregunta 

	ORDER BY Likes DESC, Id DESC

RETURN
END
GO





CREATE PROCEDURE DarLike 
	@IdRespuesta INT
AS
BEGIN
	UPDATE Respuesta SET Likes = Likes + 1 WHERE Id = @IdRespuesta

	SELECT Likes FROM Respuesta WHERE Id = @IdRespuesta

RETURN
END
GO


CREATE PROCEDURE RegistrarUsuario
	@NombreCompleto varchar(100),
	@NombreUsuario varchar(20),
	@Contrasena varchar(10),
	@IdRol INT
AS

BEGIN
	DECLARE @IdUsuarioLast INT

	INSERT INTO Usuario (NombreCompleto,NombreUsuario,Contrasena,IdRol)
	VALUES (@NombreCompleto,@NombreUsuario,@Contrasena,@IdRol)

	SELECT 
		Usuario.Id,Usuario.NombreCompleto,Usuario.NombreUsuario,Usuario.Contrasena,Usuario.IdRol, 
		Rol.NombreRol

	FROM Usuario 
	INNER JOIN Rol ON Usuario.IdRol = Rol.Id

	WHERE Usuario.Id = CONVERT(INT,SCOPE_IDENTITY())

END
GO
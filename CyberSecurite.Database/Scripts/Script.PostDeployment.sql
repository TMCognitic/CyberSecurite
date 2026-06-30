IF(NOT EXISTS(SELECT * FROM Utilisateur))
BEGIN
	INSERT INTO Utilisateur ([Nom], [Prenom], [Email], [Passwd], [IsAdmin]) VALUES (N'Doe', N'John', N'john.doe@test.be', HASHBYTES('SHA2_512', N'Test1234='), 1);
	INSERT INTO Utilisateur ([Nom], [Prenom], [Email], [Passwd]) VALUES (N'Doe', N'Jane', N'jane.doe@test.be', HASHBYTES('SHA2_512', N'Test1234='));

	INSERT INTO DataSample ([Value]) VALUES 
	  (N'Sample 1')
	, (N'Sample 2')
	, (N'Sample 3');
END

-- 0) Baza
IF DB_ID(N'Projekat-Softveri') IS NULL
    CREATE DATABASE [Projekat-Softveri];
GO
USE [Projekat-Softveri];
GO

-- 1) Bibliotekar (za login): admin/admin
IF NOT EXISTS (SELECT 1 FROM dbo.Bibliotekar WHERE username = N'admin')
BEGIN
    INSERT dbo.Bibliotekar(ime, prezime, username, password)
    VALUES (N'Iva', N'Kostić', N'admin', N'admin');   -- za projekat: plain-text
END
GO

-- 2) Šifrarnik članstva
IF NOT EXISTS (SELECT 1 FROM dbo.Clanstvo)
BEGIN
    INSERT dbo.Clanstvo(cena, vrsta) 
    VALUES (500, N'Studentsko'), (1000, N'Osnovno'), (1500, N'Premium');
END
GO

-- 3) Članovi
DECLARE @idClanstvoOsnovno BIGINT  = (SELECT TOP 1 idClanstvo FROM dbo.Clanstvo WHERE vrsta = N'Osnovno');
DECLARE @idClanstvoStudent BIGINT  = (SELECT TOP 1 idClanstvo FROM dbo.Clanstvo WHERE vrsta = N'Studentsko');

IF NOT EXISTS (SELECT 1 FROM dbo.Clan)
BEGIN
    INSERT dbo.Clan(ime, prezime, telefon, datumOd, datumDo, idClanstvo) VALUES
    (N'Marko',  N'Marković', 38164111222, CONVERT(date, GETDATE()), DATEADD(month, 12, CONVERT(date, GETDATE())), @idClanstvoOsnovno),
    (N'Jelena', N'Janković', 38163888777, CONVERT(date, GETDATE()), DATEADD(month,  6, CONVERT(date, GETDATE())), @idClanstvoStudent);
END
GO

-- 4) Knjige
IF NOT EXISTS (SELECT 1 FROM dbo.Knjiga)
BEGIN
    INSERT dbo.Knjiga(naziv, imePisca, prezimePisca) VALUES
    (N'Na Drini ćuprija',       N'Ivo',     N'Andrić'),
    (N'Prokleta Avlija',        N'Ivo',     N'Andrić'),
    (N'Stranci',                N'Albert',  N'Camus'),
    (N'Zločin i kazna',         N'Fjodor',  N'Dostojevski'),
    (N'Mali princ',             N'Antoine', N'de Saint-Exupéry');
END
GO

-- 5) Jedna test pozajmica (header + 2 stavke)
DECLARE @idClan BIGINT = (SELECT TOP 1 idClan FROM dbo.Clan ORDER BY idClan);
DECLARE @idBib  BIGINT = (SELECT TOP 1 idBibliotekar FROM dbo.Bibliotekar WHERE username = N'admin');

IF NOT EXISTS (SELECT 1 FROM dbo.Pozajmica)
BEGIN
    INSERT dbo.Pozajmica(datumOd, idClan, idBibliotekar)
    VALUES (CONVERT(date, GETDATE()), @idClan, @idBib);

    DECLARE @idPoz BIGINT = SCOPE_IDENTITY();

    DECLARE @idK1 BIGINT = (SELECT TOP 1 idKnjiga FROM dbo.Knjiga ORDER BY idKnjiga);
    DECLARE @idK2 BIGINT = (SELECT idKnjiga FROM (
        SELECT idKnjiga, ROW_NUMBER() OVER (ORDER BY idKnjiga) rn FROM dbo.Knjiga
    ) t WHERE rn = 2);

    INSERT dbo.StavkaPozajmice(idPozajmica, rokPozajmice, idKnjiga) VALUES
    (@idPoz, DATEADD(day, 14, CONVERT(date, GETDATE())), @idK1),
    (@idPoz, DATEADD(day, 14, CONVERT(date, GETDATE())), @idK2);
END
GO


SELECT * FROM dbo.Bibliotekar;
SELECT * FROM dbo.Knjiga;
SELECT * FROM dbo.Clanstvo;
SELECT * FROM dbo.Clan;
SELECT * FROM dbo.Pozajmica;
SELECT * FROM dbo.StavkaPozajmice;

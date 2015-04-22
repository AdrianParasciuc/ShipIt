
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/24/2015 00:59:48
-- Generated from EDMX file: C:\Users\adrian.parasciuc\Documents\visual studio 2013\Projects\AccesaChallengePortal\AccesaChallengePortal\DatabaseLink\ACPModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ACPDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Feedback__Respon__4CA06362]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Feedbacks] DROP CONSTRAINT [FK__Feedback__Respon__4CA06362];
GO
IF OBJECT_ID(N'[dbo].[FK__Feedback__UserId__4D94879B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Feedbacks] DROP CONSTRAINT [FK__Feedback__UserId__4D94879B];
GO
IF OBJECT_ID(N'[dbo].[FK__Questions__Chall__3F466844]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Questions] DROP CONSTRAINT [FK__Questions__Chall__3F466844];
GO
IF OBJECT_ID(N'[dbo].[FK__Responses__Quest__4316F928]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Responses] DROP CONSTRAINT [FK__Responses__Quest__4316F928];
GO
IF OBJECT_ID(N'[dbo].[FK__Responses__UserI__4222D4EF]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Responses] DROP CONSTRAINT [FK__Responses__UserI__4222D4EF];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Challenges]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Challenges];
GO
IF OBJECT_ID(N'[dbo].[Feedbacks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Feedbacks];
GO
IF OBJECT_ID(N'[dbo].[Questions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Questions];
GO
IF OBJECT_ID(N'[dbo].[Responses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Responses];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Challenges'
CREATE TABLE [dbo].[Challenges] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] varchar(50)  NOT NULL
);
GO

-- Creating table 'Questions'
CREATE TABLE [dbo].[Questions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Body] varchar(max)  NOT NULL,
    [ChallengeId] int  NULL,
    [RequiresFile] bit  NULL
);
GO

-- Creating table 'Responses'
CREATE TABLE [dbo].[Responses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ResponseData] varchar(max)  NOT NULL,
    [FilePath] varchar(200)  NULL,
    [UserId] int  NOT NULL,
    [QuestionId] int  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] varchar(50)  NOT NULL,
    [LastName] varchar(50)  NOT NULL,
    [Username] varchar(50)  NOT NULL,
    [Password] varchar(50)  NOT NULL,
    [IsAdmin] bit  NOT NULL
);
GO

-- Creating table 'Feedbacks'
CREATE TABLE [dbo].[Feedbacks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Grade] int  NULL,
    [Comment] varchar(max)  NULL,
    [ResponseId] int  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Challenges'
ALTER TABLE [dbo].[Challenges]
ADD CONSTRAINT [PK_Challenges]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Questions'
ALTER TABLE [dbo].[Questions]
ADD CONSTRAINT [PK_Questions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Responses'
ALTER TABLE [dbo].[Responses]
ADD CONSTRAINT [PK_Responses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Feedbacks'
ALTER TABLE [dbo].[Feedbacks]
ADD CONSTRAINT [PK_Feedbacks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ChallengeId] in table 'Questions'
ALTER TABLE [dbo].[Questions]
ADD CONSTRAINT [FK__Questions__Chall__3F466844]
    FOREIGN KEY ([ChallengeId])
    REFERENCES [dbo].[Challenges]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK__Questions__Chall__3F466844'
CREATE INDEX [IX_FK__Questions__Chall__3F466844]
ON [dbo].[Questions]
    ([ChallengeId]);
GO

-- Creating foreign key on [QuestionId] in table 'Responses'
ALTER TABLE [dbo].[Responses]
ADD CONSTRAINT [FK__Responses__Quest__4316F928]
    FOREIGN KEY ([QuestionId])
    REFERENCES [dbo].[Questions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK__Responses__Quest__4316F928'
CREATE INDEX [IX_FK__Responses__Quest__4316F928]
ON [dbo].[Responses]
    ([QuestionId]);
GO

-- Creating foreign key on [UserId] in table 'Responses'
ALTER TABLE [dbo].[Responses]
ADD CONSTRAINT [FK__Responses__UserI__4222D4EF]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK__Responses__UserI__4222D4EF'
CREATE INDEX [IX_FK__Responses__UserI__4222D4EF]
ON [dbo].[Responses]
    ([UserId]);
GO

-- Creating foreign key on [ResponseId] in table 'Feedbacks'
ALTER TABLE [dbo].[Feedbacks]
ADD CONSTRAINT [FK__Feedback__Respon__4CA06362]
    FOREIGN KEY ([ResponseId])
    REFERENCES [dbo].[Responses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK__Feedback__Respon__4CA06362'
CREATE INDEX [IX_FK__Feedback__Respon__4CA06362]
ON [dbo].[Feedbacks]
    ([ResponseId]);
GO

-- Creating foreign key on [UserId] in table 'Feedbacks'
ALTER TABLE [dbo].[Feedbacks]
ADD CONSTRAINT [FK__Feedback__UserId__4D94879B]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK__Feedback__UserId__4D94879B'
CREATE INDEX [IX_FK__Feedback__UserId__4D94879B]
ON [dbo].[Feedbacks]
    ([UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
select * from relationships;
UPDATE dbo.[Relationships] SET pending = 0 WHERE (user1 = 'chika' AND user2 = 'omar') OR (user1 = 'omar' AND user2 = 'chika')
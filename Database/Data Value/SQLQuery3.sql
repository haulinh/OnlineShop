select * 
from dbo.Role

select * 
from dbo.UserGroup

select * 
from dbo.Credential

INSERT INTO dbo.Credential (UserGroupID,RoleID)
VALUES ('ADMIN', 'ADD_CONTENT'),
('ADMIN', 'ADD_USER'),
('ADMIN', 'DEL_USER'),
('ADMIN', 'EDIT_CONTENT'),
('ADMIN', 'EDIT_USER'),
('ADMIN', 'VIEW_USER'),
('MOD', 'EDIT_USER'),
('MOD', 'VIEW_USER')
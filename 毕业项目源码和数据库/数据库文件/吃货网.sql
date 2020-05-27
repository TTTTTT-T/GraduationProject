create database ChowhoundNet 
use ChowhoundNet

create table UserInfo --�û���Ϣ
(
   userID int primary key identity(1,1),
   username varchar(20),--����/�ǳ�
   userpic nvarchar(max),--ͷ��ͼƬ·�� 
   phone int,--�ֻ���
   pwd varchar(20),--����
   sex char(2),--�Ա�
   Birthday nvarchar(20),--����
   isDelete int default(0)--�Ƿ�ɾ��,0Ϊ��ʾ��1Ϊ����
)
create table MenuType --��������
(
   typeid int primary key identity(1,1),
   typeName nvarchar(10) --��������
)
create table Menuinformation --����������Ϣ
(
MenuinformationID int primary key identity(1,1),--����ID
MenuinformationName varchar(50),--��������
TypeID int foreign key(TypeID) references MenuType(typeid),--��Ӱ����id--
Technology varchar(50),--����
Dishes varchar(50),--��ζ
difficulty varchar(50),--�Ѷ�
Setuptime varchar(50),--׼��ʱ��
CookingTime varchar(50),--���ʱ��
People  varchar(50),--����
MenuinformationImg nvarchar(MAX),--ͼƬ·��
Ingredients varchar(50),--����
subsidiary varchar(50),--����
commenttime nvarchar(20)default(getdate()),   --����ʱ��
viewscount int--�������
)
create table CommentMenu
(
CommentMenuID int primary key identity(1,1),--����ID
content nvarchar(max),--��������
userID int foreign key(userID) references userinfo(userID),--ȡ�û�����
MenuinformationID int foreign key(MenuinformationID) references Menuinformation(MenuinformationID),   --ȡ��������
commenttime nvarchar(20)default(getdate()),   --����ʱ��


)
--�����Ҳ��ױ�
create table publish(
publishID int primary key identity(1,1),
publishName nvarchar(MAX),--�����Ҳ�������
publishImg nvarchar(MAX),--ͼƬ·��
userID int foreign key(userID) references userinfo(userID),--ȡ�û�����
commenttime nvarchar(20)default(getdate()),   --����ʱ��
)
create table Comment --���۱�
(
cID int primary key identity(1,1),
CTechnology varchar(50),--����
CDishes varchar(50),--��ζ
Cdifficulty varchar(50),--�Ѷ�
CSetuptime varchar(50),--׼��ʱ��
CCookingTime varchar(50),--���ʱ��
CPeople  varchar(50),--����
CMenuinformationImg nvarchar(MAX),--ͼƬ·��
CIngredients varchar(50),--����
Csubsidiary varchar(50),--����
userID int foreign key(userID) references userinfo(userID),--ȡ�û�����
publishID int foreign key(publishID) references publish(publishID),   --ȡ��������
commenttime nvarchar(20)default(getdate()),   --����ʱ��

)
create table HotList --������
(
   hlid int primary key identity(1,1),
   hlid int foreign key(MenuinformationID) references Menuinformation(MenuinformationID),--��Ӱ��Ϣ

)

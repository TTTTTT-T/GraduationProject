create database ChowhoundNet 
use ChowhoundNet

create table UserInfo --用户信息
(
   userID int primary key identity(1,1),
   username varchar(20),--姓名/昵称
   userpic nvarchar(max),--头像图片路径 
   phone int,--手机号
   pwd varchar(20),--密码
   sex char(2),--性别
   Birthday nvarchar(20),--生日
   isDelete int default(0)--是否删除,0为显示，1为隐藏
)
create table MenuType --菜谱类型
(
   typeid int primary key identity(1,1),
   typeName nvarchar(10) --类型名称
)
create table Menuinformation --发布菜谱信息
(
MenuinformationID int primary key identity(1,1),--菜谱ID
MenuinformationName varchar(50),--菜谱名称
TypeID int foreign key(TypeID) references MenuType(typeid),--电影类型id--
Technology varchar(50),--工艺
Dishes varchar(50),--口味
difficulty varchar(50),--难度
Setuptime varchar(50),--准备时间
CookingTime varchar(50),--烹饪时间
People  varchar(50),--人数
MenuinformationImg nvarchar(MAX),--图片路径
Ingredients varchar(50),--主料
subsidiary varchar(50),--辅料
commenttime nvarchar(20)default(getdate()),   --发布时间
viewscount int--浏览次数
)
create table CommentMenu
(
CommentMenuID int primary key identity(1,1),--评论ID
content nvarchar(max),--评论内容
userID int foreign key(userID) references userinfo(userID),--取用户姓名
MenuinformationID int foreign key(MenuinformationID) references Menuinformation(MenuinformationID),   --取菜谱名称
commenttime nvarchar(20)default(getdate()),   --评论时间


)
--发布找菜谱表
create table publish(
publishID int primary key identity(1,1),
publishName nvarchar(MAX),--发布找菜谱名称
publishImg nvarchar(MAX),--图片路径
userID int foreign key(userID) references userinfo(userID),--取用户姓名
commenttime nvarchar(20)default(getdate()),   --评论时间
)
create table Comment --评论表
(
cID int primary key identity(1,1),
CTechnology varchar(50),--工艺
CDishes varchar(50),--口味
Cdifficulty varchar(50),--难度
CSetuptime varchar(50),--准备时间
CCookingTime varchar(50),--烹饪时间
CPeople  varchar(50),--人数
CMenuinformationImg nvarchar(MAX),--图片路径
CIngredients varchar(50),--主料
Csubsidiary varchar(50),--辅料
userID int foreign key(userID) references userinfo(userID),--取用户姓名
publishID int foreign key(publishID) references publish(publishID),   --取菜谱名称
commenttime nvarchar(20)default(getdate()),   --评论时间

)
create table HotList --热评榜
(
   hlid int primary key identity(1,1),
   hlid int foreign key(MenuinformationID) references Menuinformation(MenuinformationID),--电影信息

)

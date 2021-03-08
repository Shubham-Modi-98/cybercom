Insert into tblImages values ('angry-bird.jpg',1)
Insert into tblImages values ('asplogo.jpg',2)
Insert into tblImages values ('assassins.jpg',3)
Insert into tblImages values ('greenq.jpg',4)
Insert into tblImages values ('gtavs.jpg',5)
Insert into tblImages values ('h2.jpg',6)
Insert into tblImages values ('h3.jpg',7)
Insert into tblImages values ('h4.jpg',8)
Insert into tblImages values ('h5.jpg',9)
Insert into tblImages values ('manquiz.jpg',10)
Insert into tblImages values ('quiz-icon.jpg',11)
Insert into tblImages values ('quiz-icon1.jpg',12)
Insert into tblImages values ('QuizSplash.jpg',13)

select * from tblImages

Create Procedure spGetImages
As 
Begin
	select Name, ImgOrder from tblImages
End

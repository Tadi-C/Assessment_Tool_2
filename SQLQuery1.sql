select * from Question 

select Question_ID, Question_Text, Question_Option1, Question_Option2, Question_Option3, Question_Option4 from Question where Section_ID = 'A' and Question_ID like '1A%' 
--#7.2 დაწერეთ sql რომელიც დააბრუნებს ყველა მასწავლებელს, რომელიც ასწავლის მოსწავლეს, რომელის სახელია: „გიორგი“.

Select DISTINCT  TeacherName, TeacherLastName from Teacher 
						inner join Dependence on Teacher.Sub = Dependence.Sub 
						inner join Pupil on Dependence.Class = Pupil.Class where Pupil.FirstName like N'%გიორგი%'
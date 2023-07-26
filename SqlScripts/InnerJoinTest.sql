USE FinalCaseStudy13;


SELECT T.ID
,A1.ID AS Accnt1, A1.Account_Status
,A2.ID AS Accnt2, A2.Account_Status
FROM Transactions AS T
INNER JOIN Account AS A1
	ON T.Account_ID = A1.ID
INNER JOIN Account AS A2
	ON T.Account_ID_2 = A2.ID
WHERE A1.Account_Status = 'SOFT DELETE' AND A2.Account_Status = 'SOFT DELETE';

CREATE TABLE admin
(
  id INT PRIMARY KEY IDENTITY (1,1),
  username VARCHAR (MAX) NULL,
  email VARCHAR (MAX) NULL,
  password VARCHAR (MAX) NULL,
  dob DATE NULL,
  pet VARCHAR (MAX) NULL,
  pet_age VARCHAR (MAX) NULL,
  injection_status VARCHAR (MAX) NULL,
  medicine_needed VARCHAR (MAX) NULL,
  start_date DATE NULL,
  checkout_date DATE NULL,
  payment_amount INT DEFAULT ((0)) NOT NULL,
  payment_status VARCHAR (MAX) NULL,
  date_created DATE NULL,
  usertype INT DEFAULT ((1)) NOT NULL,
  login_status INT DEFAULT ((0)) NOT NULL,
)
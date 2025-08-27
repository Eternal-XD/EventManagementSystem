# EventManagmentSystem

CREATE DATABASE ems;

USE ems;

CREATE TABLE Attendee(
    id int PRIMARY KEY AUTO_INCREMENT,
    name varchar(100),
    password varchar(16),
    contactnumber varchar(20),
    gender varchar (20)
);

CREATE TABLE organizer(
	id int PRIMARY KEY AUTO_INCREMENT,
    name varchar(100),
    password varchar(16),
    contactnumber varchar(20),
    email varchar (100),
    gender varchar(20)
);

CREATE TABLE events(
	id int PRIMARY KEY AUTO_INCREMENT,
    name varchar(255),
    date datetime,
    location varchar(255),
    description varchar(255),
    organizer_id int,
    availability bit DEFAULT(1),
    
    
    FOREIGN KEY (organizer_id) REFERENCES organizer(id)
);

CREATE TABLE ticket(
	id int PRIMARY KEY AUTO_INCREMENT,
    event_id int,
    tickettype varchar(255),
    price double,
    quantity int,
    availability bit,
    
    FOREIGN KEY (event_id) REFERENCES events(id)
);
CREATE TABLE purchase(
	id int PRIMARY KEY AUTO_INCREMENT,
    ticket_id int,
    attendee_id int,
    quantity int,
    total double,
    
    FOREIGN KEY (ticket_id) REFERENCES ticket(id),
    FOREIGN KEY (attendee_id) REFERENCES attendee(id)
);

CREATE TABLE payment(
	id int PRIMARY KEY AUTO_INCREMENT,
    purchase_id int,
    type varchar(20),
    number varchar(16),
    name varchar(255),
    expiry date,
    ccv varchar(3),
    
    FOREIGN KEY (purchase_id) REFERENCES purchase(id)
)


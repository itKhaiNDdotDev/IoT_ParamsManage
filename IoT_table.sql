create table users (
	uid varchar(255) primary key,
    full_name nvarchar(255) not null,
    u_role varchar(50) not null,
    is_active varchar(5) not null,
    email varchar(255) not null,
    passwd varchar(255) not null,
    create_time datetime,
    update_time datetime
);

create table devices (
	device_id varchar(255) primary key,
    uid varchar(255) not null,
    device_name nvarchar(255),
    device_description text,
    img_url text,
    is_active varchar(5) not null,
    create_time datetime,
    update_time datetime,
    
    foreign key (uid) references users(uid)
);

create table auth_tokens (
	id bigint primary key,
    uid varchar(255) not null,
    device_token varchar(255) not null,
    create_time datetime,
    update_time datetime,
    
    foreign key (uid) references users(uid)
);

create table attribute(
	attribute_id varchar(255) primary key,
    device_id varchar(255) not null,
    a_name enum('1', '2', '3', '4'),
    attribute_des text,
    create_time datetime,
    update_time datetime,
    
    foreign key (device_id) references devices(device_id)
);

create table datas (
	d_id varchar(255) primary key,
    attribute_id varchar(255) not null,
    d_values float,
    update_time datetime,
    
    foreign key (attribute_id) references attribute(attribute_id)
);
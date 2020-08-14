select * from users

select * from leaderboard

select * from league

select * from location

select * from league_users

insert into league (league_name, league_admin, course_id, league_start, league_end, score_league) VALUES ('Bretts League', 'user', '2', '2020-08-15', '2020-09-20', 1)
insert into league (league_name, league_admin, course_id, league_start, league_end, score_league) VALUES ('Junior League', 'user', '1', '2020-09-15', '2020-10-20', 1)

insert into league (league_name, league_admin, course_id, league_start, league_end, score_league) VALUES ('Champions League', 'user', '3', '2020-08-15', '2020-09-20', 1)

insert into league (league_name, league_admin, course_id, league_start, league_end, score_league) VALUES ('Ultra League', 'user', '4', '2020-08-20', '2020-09-30', 1)

insert into league (league_name, league_admin, course_id, league_start, league_end, score_league) VALUES ('Master League', 'user', '5', '2020-10-15', '2020-11-20', 1)

insert into league (league_name, league_admin, course_id, league_start, league_end, score_league) VALUES ('Great League', 'user', '2', '2020-08-18', '2020-09-20', 1)

insert into league (league_name, league_admin, course_id, league_start, league_end, score_league) VALUES ('Loser League', 'user', '2', '2020-11-15', '2020-12-20', 1)
insert into league (league_name, league_admin, course_id, league_start, league_end, score_league) VALUES ('Public League', 'user', '4', '2020-12-15', '2020-2-21', 1)
insert into league (league_name, league_admin, course_id, league_start, league_end, score_league) VALUES ('Private League', 'user', '5', '2020-08-15', '2020-09-20', 1)
insert into league (league_name, league_admin, course_id, league_start, league_end, score_league) VALUES ('Winners League', 'user', '2', '2020-10-14', '2020-12-15', 1)


insert into leaderboard (week, total_score, league_id, user_id) VALUES (1, 70, 1, 1)

insert into location (course_name, holes, address, city, state, zip) VALUES ('West Penn', 18, '123 Main Street', 'Pittsburgh', 'PA', 15212) 
insert into location (course_name, holes, address, city, state, zip) VALUES ('North Penn', 18, '245 North Penn Ave', 'Pittsburgh', 'PA', 15212) 
insert into location (course_name, holes, address, city, state, zip) VALUES ('East Penn', 18, '378 East Penn Street', 'Pittsburgh', 'PA', 15212) 
insert into location (course_name, holes, address, city, state, zip) VALUES ('South Penn', 18, '47 South Penn Drive', 'Pittsburgh', 'PA', 15212)
insert into location (course_name, holes, address, city, state, zip) VALUES ('Pebble Beach', 18, '78 Pebble Beach Drive', 'Pittsburgh', 'PA', 15212)

insert into league_users (league_id, user_id) VALUES (1, 5)


select * from users
JOIN league ON league.user_id = users.user_id
JOIN leaderboard ON leaderboard.league_id = league.league_id
JOIN location ON location.course_id = league.course_id

SELECT league_id, league_name, league_admin, course_id, league_start, league_end, score_league FROM league WHERE league_name = 'BrettsLeague'

select * from league

insert into leaderboard VALUES (2, 75, 2, 1)

insert into leaderboard VALUES (2, 80, 2, 1)

insert into leaderboard VALUES (1, 70, 2, 1)

insert into leaderboard VALUES (1, 73, 4, 1)

insert into leaderboard VALUES (1, 87, 3, 1)


insert into league (league_name, league_admin, course_id, league_start, league_end, score_league) VALUES ('Loser League', '123', '1', '2020-08-15', '2020-09-20', 1)

insert into league (league_name, league_admin, course_id, league_start, league_end, score_league) VALUES ('New League', 'user', '1', '2020-08-15', '2020-09-20', 1)

select username from users join league on users.user_id = league.user_id  where league.league_id = 2

select * from league_users
insert into league_users values (1,2)

SELECT * FROM league join leaderboard on leaderboard.league_id = league.league_id join users on users.user_id = leaderboard.user_id WHERE users.user_id = 3
select
select * from league

delete from league where league_name = 'Bennys League'

select * from users join league on users.user_id = league.user_id  where league.league_id = @league_id
select * from users join leaderboard on users.user_id = leaderboard.user_id join league on leaderboard.league_id = league.league_id where league.league_id = @league_id
CREATE PROCEDURE add_100_members(IN last_index_member INT) AS
$$
BEGIN
    FOR i IN last_index_member + 1..last_index_member + 100
        LOOP
            INSERT INTO Members (Name, Email) VALUES ('Name' || i, 'name' || i || '@email.com');
        END LOOP;
END;
$$ LANGUAGE PLPGSQL;

CREATE FUNCTION get_last_member_id() RETURNS INT AS
$$
DECLARE
    i INT;
BEGIN
    SELECT Id
    FROM Members
    ORDER BY Id DESC
    LIMIT 1
    INTO i;

    RETURN i;
END;

$$ LANGUAGE PLPGSQL;


CREATE FUNCTION get_last_lesson_id() RETURNS INT AS
$$
DECLARE
    MaxId INT;
BEGIN
    SELECT Id
    FROM Lessons
    ORDER BY Id DESC
    LIMIT 1
    INTO MaxId;

    RETURN MaxId;
END;
$$ LANGUAGE PLPGSQL;

CREATE PROCEDURE add_100_lessons(last_lesson_index INT) AS
$$
BEGIN
    FOR i IN last_lesson_index + 1 .. last_lesson_index + 100
        LOOP
            INSERT INTO Lessons (LessonName, Date) VALUES ('LessonName' || i, DEFAULT);
        END LOOP;
END;
$$ LANGUAGE PLPGSQL;

DO
$$
    DECLARE
        MaxId INT;
    BEGIN
        MaxId := get_last_member_id();
        CALL add_100_members(MaxId);
    END;
$$;

DO
$$
    DECLARE
        MaxId INT;
    BEGIN
        MaxId := get_last_lesson_id();
        CALL add_100_lessons(MaxId);
    END;
$$;

CREATE PROCEDURE add_100_member_lessons() AS
$$
DECLARE
    lesson_id INT;
    member_id INT;
BEGIN
    FOR i IN 1..100
        LOOP
            lesson_id := FLOOR(RANDOM() * (100 - 1 + 1) + 1);
            member_id := FLOOR(RANDOM() * (100 - 1 + 1) + 1);
            IF NOT EXISTS (SELECT
                           FROM MemberLessons
                           WHERE (LessonId = lesson_id AND MemberId = member_id)
                              OR (LessonId = member_id AND MemberId = lesson_id))
            THEN
                INSERT INTO MemberLessons (LessonId, MemberId) VALUES (lesson_id, member_id);
            END IF;
        END LOOP;
END;
$$ LANGUAGE PLPGSQL;

CREATE INDEX member_email
    ON Members (email);

CREATE INDEX member_id
    ON Members (id);

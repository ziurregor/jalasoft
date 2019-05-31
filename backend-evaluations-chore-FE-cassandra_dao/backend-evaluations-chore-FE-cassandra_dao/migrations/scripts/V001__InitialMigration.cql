CREATE TYPE option_score (
    option_id  UUID,
    sequence INT,
    weight INT,
    user_selected BOOLEAN,
    is_answer BOOLEAN
);

CREATE TYPE question_score (
    question_id UUID,
    weighted BOOLEAN,
    weight INT,
    score DOUBLE,
    score_formula TEXT,
    options_list LIST<FROZEN<option_score>>,
    answers LIST<UUID>
);


CREATE TYPE qualification_range (
    id UUID,
    start INT,
    end INT,
    qualification TEXT
);

CREATE TABLE evaluation_score(
    id UUID,
    evaluation_id UUID,
    date TIMESTAMP,
    owner TEXT,
    name TEXT,
    score_formula TEXT,
    score DOUBLE,
    weight INT,
    qualification UUID,
    qualification_ranges LIST<FROZEN<qualification_range>>,
    question_list LIST<FROZEN<question_score>>,
    PRIMARY KEY ( evaluation_id, id )
);

CREATE INDEX ON evaluation_score (id);
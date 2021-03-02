CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    migration_id character varying(150) NOT NULL,
    product_version character varying(32) NOT NULL,
    CONSTRAINT pk___ef_migrations_history PRIMARY KEY (migration_id)
);

START TRANSACTION;

CREATE TABLE to_do_items (
    id uuid NOT NULL,
    title text NOT NULL,
    note text NULL,
    done boolean NOT NULL,
    is_deleted boolean NOT NULL,
    delete_date timestamp with time zone NULL,
    created_by text NOT NULL,
    create_date timestamp with time zone NOT NULL,
    last_modified_by text NULL,
    last_modified_date timestamp with time zone NULL,
    CONSTRAINT pk_to_do_items PRIMARY KEY (id)
);

CREATE INDEX ix_to_do_items_title ON to_do_items (title);

INSERT INTO "__EFMigrationsHistory" (migration_id, product_version)
VALUES ('20210302072635_CreateToDoItemTable', '5.0.3');

COMMIT;


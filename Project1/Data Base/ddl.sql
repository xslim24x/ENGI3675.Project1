
-- Table: to store rows about ...;





CREATE TABLE "Project1"."Project 1"
(
  "Paint Names" text NOT NULL,
  "Litres" integer,
  CONSTRAINT "Paint Names" PRIMARY KEY ("Paint Names")
)
WITH (
  OIDS=FALSE
);
ALTER TABLE "Project1"."Project 1"
  OWNER TO postgres;

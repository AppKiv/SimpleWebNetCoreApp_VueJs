-- Table: blog.post

-- DROP TABLE blog.post;

CREATE TABLE blog.post
(
  body text NOT NULL,
  header text NOT NULL,
  publish_date timestamp with time zone NOT NULL,
  post_id bigint NOT NULL,
  author_id bigint,
  preview text
)
WITH (
  OIDS=FALSE
);
ALTER TABLE blog.post
  OWNER TO postgres;

-- Table: blog.post_tag

-- DROP TABLE blog.post_tag;

CREATE TABLE blog.post_tag
(
  post_id bigint NOT NULL,
  tag text NOT NULL,
  rank integer DEFAULT 0
)
WITH (
  OIDS=FALSE
);
ALTER TABLE blog.post_tag
  OWNER TO postgres;

-- Function: blog.tags_get()

-- DROP FUNCTION blog.tags_get();

CREATE OR REPLACE FUNCTION blog.tags_get()
  RETURNS TABLE(tag text, cnt bigint) AS
$BODY$
BEGIN
	RETURN QUERY

	select t.tag, count(1) as cnt from blog.post_tag t group by t.tag order by cnt desc;
END
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100
  ROWS 1000;
ALTER FUNCTION blog.tags_get()
  OWNER TO postgres;

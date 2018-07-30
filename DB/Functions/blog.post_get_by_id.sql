-- Function: blog.post_get_by_id(bigint)

-- DROP FUNCTION blog.post_get_by_id(bigint);

CREATE OR REPLACE FUNCTION blog.post_get_by_id(IN _id bigint)
  RETURNS TABLE(post_id bigint, header text, preview text, body text, publish_date timestamp with time zone, tags text) AS
$BODY$
BEGIN
	RETURN QUERY

	select  p.post_id, p.header, p.preview, p.body
		   ,p.publish_date
		   ,(select string_agg(t.tag, ',') from (
			select pt.tag from blog.post_tag pt where pt.post_id=_id--.post_id 
			order by pt.rank desc
			) as t) as tags
	from blog.post as p where p.post_id=_id;
END
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100
  ROWS 1000;
ALTER FUNCTION blog.post_get_by_id(bigint)
  OWNER TO postgres;

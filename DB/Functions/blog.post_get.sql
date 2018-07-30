-- Function: blog.post_get(text)

-- DROP FUNCTION blog.post_get(text);

CREATE OR REPLACE FUNCTION blog.post_get(IN _tags text)
  RETURNS TABLE(post_id bigint, header text, preview text, publish_date timestamp with time zone) AS
$BODY$
BEGIN
	RETURN QUERY

	select 
		p.post_id, p.header, p.preview, p.publish_date 
	from blog.post p 
	where 
		p.post_id in (select distinct t.post_id from blog.post_tag t
						inner join (select unnest(string_to_array( _tags, ',')) as tag ) as st on st.tag=t.tag
		)
	order by 
		p.publish_date desc;
END
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100
  ROWS 1000;
ALTER FUNCTION blog.post_get(text)
  OWNER TO postgres;

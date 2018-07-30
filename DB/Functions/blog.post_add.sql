-- Function: blog.post_add(text, text, text, bigint)

-- DROP FUNCTION blog.post_add(text, text, text, bigint);

CREATE OR REPLACE FUNCTION blog.post_add(
    IN _header text,
    IN _body text,
    IN _preview text,
    IN _user_id bigint)
  RETURNS TABLE(post_id bigint) AS
$BODY$
DECLARE
    post_id bigint;
BEGIN

	post_id := nextval('blog.post_seq');
        
	INSERT INTO blog.post(header, body, preview, post_id, author_id,publish_date)
	VALUES(_header,_body,_preview, post_id,_user_id,now());

	RETURN QUERY VALUES(post_id);
END;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100
  ROWS 1;
ALTER FUNCTION blog.post_add(text, text, text, bigint)
  OWNER TO postgres;

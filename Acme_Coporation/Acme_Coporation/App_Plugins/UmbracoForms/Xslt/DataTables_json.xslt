<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
xmlns:msxsl="urn:schemas-microsoft-com:xslt"
xmlns:umbraco.library="urn:umbraco.library"
xmlns:user="urn:my-scripts"
exclude-result-prefixes="msxsl user umbraco.library">

  <xsl:output method="text" indent="no" encoding="utf-8" />

  <xsl:param name="records" />
  <xsl:param name="form" />

  <msxsl:script implements-prefix="user" language="JScript">
    function date2number(s) { return Number(new Date(s)); }
  </msxsl:script>

  <xsl:template match="/">


    { "iTotalDisplayRecords": "<xsl:value-of select="$records/@totalRecords"/>","iTotalRecords": "<xsl:value-of select="$records/@totalRecords"/>",  
    "formFields" : [
      "Id","Created","IP","Page Id","Link",
      <xsl:for-each select="$form//field">
        "<xsl:value-of select="caption"/>"<xsl:choose><xsl:when test="position() != last()">,</xsl:when></xsl:choose>
      </xsl:for-each>
    ],
    "aaData": [
    <xsl:for-each select="$records//uformrecord">
      <xsl:sort select="user:date2number(string(created))" data-type="number" order="descending" />

      <xsl:variable name="record" select="." />

      [
      "<xsl:value-of select="id"/>",
      "<xsl:value-of select="translate(created,'T',' ')"/>",
      "<xsl:value-of select="ip"/>",
      "<xsl:value-of select="pageid"/>",
      "&lt;a href='<xsl:value-of select="umbraco.library:NiceUrl(pageid)"/>' target='_blank'&gt;<xsl:value-of select="umbraco.library:NiceUrl(pageid)"/>&lt;/a&gt;"

      <xsl:for-each select="$form//field">
        

        <xsl:variable name="key" select="id" />
        <xsl:variable name="fieldValues">
          <xsl:choose>
            <xsl:when test="count($record//fields/child::* [fieldKey = $key]//value) &gt; 1">
              <xsl:for-each select="$record//fields/child::* [fieldKey = $key]//value">
                <xsl:value-of select="normalize-space(translate(.,',',' '))"/>
                <xsl:if test="position() != last()">, </xsl:if>
              </xsl:for-each>
            </xsl:when>
            <xsl:otherwise>
              <xsl:value-of select="normalize-space(translate( umbraco.library:Replace($record//fields/child::* [fieldKey = $key]//value,'\','\\'),',',' '))"/>
            </xsl:otherwise>
          </xsl:choose>
        </xsl:variable>

        <xsl:choose>
          <xsl:when test="position() = last() and position() = 1">
            ,"<xsl:value-of select="$fieldValues"/>"
          </xsl:when>

          <xsl:when test="position() = 1 and position() != last()">
            ,
            "<xsl:value-of select="$fieldValues"/>",
          </xsl:when>

          <xsl:when test="position() != last() and position() &gt; 1">
            "<xsl:value-of select="$fieldValues"/>",
          </xsl:when>

          <xsl:when test="position() = last() and position() &gt; 1">
            "<xsl:value-of select="$fieldValues"/>"
          </xsl:when>

          <xsl:otherwise>
            <xsl:value-of select="caption"/>
          </xsl:otherwise>
        </xsl:choose>

      </xsl:for-each>

      ]<xsl:if test="position() != last()">,</xsl:if>
    </xsl:for-each>
    ]}

  </xsl:template>



</xsl:stylesheet>
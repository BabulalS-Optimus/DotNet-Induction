<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="Students">
    <HTML>
      <BODY>
        <h1>Details of Students</h1>
        <TABLE BORDER="2">
          <TR>
            <th>Name</th>
            <th>Age</th>
            <th>Address</th>
          </TR>
          <xsl:apply-templates select="Student"/>
        </TABLE>
      </BODY>
    </HTML>
  </xsl:template>
  <xsl:template match="Student">
    <TR>
      <TD>
        <xsl:value-of select="@name"/>
      </TD>
      <TD>
        <xsl:value-of select="@age"/>
      </TD>
      <TD>
        <xsl:value-of select="Address/City"/>,  <xsl:value-of select="Address/Country"/>
      </TD>
    </TR>
  </xsl:template>
</xsl:stylesheet>
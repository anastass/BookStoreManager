# BookStoreManager

Code based on Building Web Applications with Open-Source Software on Windows with Jesse Liberty  (pluralsight.com)

## Service

<table border="1">
	<tr>
		<th>Operation</th>
		<th>Verb</th>
		<th>Example</th>
	</tr>

	<tr>
		<td>AllBooks</td>
		<td>GET /Book</td>
		<td>http://localhost:36182/Book?format=json</td>
	</tr>

	<tr>
		<td>BookById</td>
		<td>All Verbs /Book/{Id}</td>
		<td>http://localhost:36182/Book/3?format=json</td>
	</tr>

	<tr>
		<td>BookByTitle</td>
		<td>GET /Book/Title/{Title}</td>
		<td>http://localhost:36182/Book/Title/Book%20Two?format=json</td>
	</tr>

	<tr>
		<td>BookInformation</td>
		<td>POST</td>
		<td> </td>
	</tr>
</table>

To debug the service:

- Right click BookService
- Go to Debug and select Start new instance

### Service Types

	<xs:schema 
		xmlns:tns="http://schemas.datacontract.org/2004/07/BookService" 
		xmlns:xs="http://www.w3.org/2001/XMLSchema" 
		elementFormDefault="qualified" 
		targetNamespace="http://schemas.datacontract.org/2004/07/BookService">

		<xs:complexType name="BookInformation">
			<xs:sequence>
				<xs:element minOccurs="0" name="Author" nillable="true" type="xs:string"/>
				<xs:element minOccurs="0" name="Id" type="xs:int"/>
				<xs:element minOccurs="0" name="Price" type="xs:decimal"/>
				<xs:element minOccurs="0" name="Title" nillable="true" type="xs:string"/>
			</xs:sequence>
		</xs:complexType>
		<xs:element name="BookInformation" nillable="true" type="tns:BookInformation"/>

		<xs:complexType name="AllBooks">
			<xs:sequence/>
		</xs:complexType>
		<xs:element name="AllBooks" nillable="true" type="tns:AllBooks"/>

		<xs:complexType name="BookByTitle">
			<xs:sequence>
				<xs:element minOccurs="0" name="Title" nillable="true" type="xs:string"/>
			</xs:sequence>
		</xs:complexType>
		<xs:element name="BookByTitle" nillable="true" type="tns:BookByTitle"/>

		<xs:complexType name="BookById">
			<xs:sequence>
				<xs:element minOccurs="0" name="Id" type="xs:int"/>
			</xs:sequence>
		</xs:complexType>
		<xs:element name="BookById" nillable="true" type="tns:BookById"/>

		<xs:complexType name="ArrayOfBook">
			<xs:sequence>
				<xs:element minOccurs="0" maxOccurs="unbounded" name="Book" nillable="true" type="tns:Book"/>
			</xs:sequence>
		</xs:complexType>
		<xs:element name="ArrayOfBook" nillable="true" type="tns:ArrayOfBook"/>

		<xs:complexType name="Book">
			<xs:sequence>
				<xs:element minOccurs="0" name="Author" nillable="true" type="xs:string"/>
				<xs:element minOccurs="0" name="Id" type="xs:int"/>
				<xs:element minOccurs="0" name="Price" type="xs:decimal"/>
				<xs:element minOccurs="0" name="Title" nillable="true" type="xs:string"/>
			</xs:sequence>
		</xs:complexType>
		<xs:element name="Book" nillable="true" type="tns:Book"/>
	</xs:schema>

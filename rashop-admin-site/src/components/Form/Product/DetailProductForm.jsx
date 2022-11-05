import Button from "react-bootstrap/Button";
import Col from "react-bootstrap/Col";
import Form from "react-bootstrap/Form";
import Row from "react-bootstrap/Row";

function DetailProductForm({data}) {
  return (
    <Form>
       <Form.Group as={Col} controlId="productname">
        <Form.Label>Id</Form.Label>
        <Form.Control defaultValue={data.productId} type="text" placeholder="" />
      </Form.Group>
      <Form.Group as={Col} controlId="productname">
        <Form.Label>Tên sản phẩm</Form.Label>
        <Form.Control defaultValue={data.productName} type="text" placeholder="Nhập tên sản phẩm..." />
      </Form.Group>

      <Row className="mb-3">
        <Form.Group as={Col} controlId="productprice">
          <Form.Label>Giá</Form.Label>
          <Form.Control defaultValue={data.price} type="text" placeholder="Nhập giá..." />
        </Form.Group>
      </Row>

      <Row className="mb-3">
        <Form.Group as={Col} controlId="productorigin">
          <Form.Label>Xuất xứ</Form.Label>
          <Form.Control defaultValue={data.origin} type="text" placeholder="Nhập xuất xứ..." />
        </Form.Group>

        <Form.Group as={Col} controlId="productunit">
          <Form.Label>Đơn vị tính</Form.Label>
          <Form.Control defaultValue={data.unit} type="text" placeholder="Nhập đơn vị tính..." />
        </Form.Group>
      </Row>

      <Row className="mb-3">
      <Form.Group as={Col} controlId="productcate">
          <Form.Label>Danh mục</Form.Label>
          <Form.Control defaultValue={data.categoryName} type="text" placeholder="Nhập đơn vị tính..." />
        </Form.Group>

        <Form.Group as={Col} controlId="productsubcate">
          <Form.Label>Danh mục con</Form.Label>
          <Form.Control defaultValue={data.subCategoryName} type="text"/>
        </Form.Group>

      </Row>

      <Form.Group className="mb-3" id="productimage">
      <Form.Label>Chọn hình ảnh</Form.Label>
        <Form.Control type="file" label="Check me out" />
      </Form.Group>
    </Form>
  );
}

export default DetailProductForm;

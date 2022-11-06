import Button from "react-bootstrap/Button";
import Col from "react-bootstrap/Col";
import Form from "react-bootstrap/Form";
import Row from "react-bootstrap/Row";

function AddProductForm() {
  return (
    <Form>
      <Form.Group as={Col} controlId="productname">
        <Form.Label>Tên sản phẩm</Form.Label>
        <Form.Control type="text" placeholder="Nhập tên sản phẩm..." />
      </Form.Group>

      <Row className="mb-3">
        <Form.Group as={Col} controlId="productprice">
          <Form.Label>Giá</Form.Label>
          <Form.Control type="text" placeholder="Nhập giá..." />
        </Form.Group>
      </Row>

      <Row className="mb-3">
        <Form.Group as={Col} controlId="productorigin">
          <Form.Label>Xuất xứ</Form.Label>
          <Form.Control type="text" placeholder="Nhập xuất xứ..." />
        </Form.Group>

        <Form.Group as={Col} controlId="productunit">
          <Form.Label>Đơn vị tính</Form.Label>
          <Form.Control type="text" placeholder="Nhập đơn vị tính..." />
        </Form.Group>
      </Row>

      <Row className="mb-3">
        <Form.Group as={Col} controlId="productcate">
          <Form.Label>Danh mục</Form.Label>
          <Form.Select>
            <option>Choose...</option>
            <option>...</option>
          </Form.Select>
        </Form.Group>

        <Form.Group as={Col} controlId="productsubcate">
          <Form.Label>Danh mục con</Form.Label>
          <Form.Select defaultValue="Choose...">
            <option>Choose...</option>
            <option>...</option>
          </Form.Select>
        </Form.Group>
      </Row>

      <Form.Group className="mb-3" id="productimage">
        <Form.Label>Chọn hình ảnh</Form.Label>
        <Form.Control type="file" label="Check me out" />
      </Form.Group>
    </Form>
  );
}

export default AddProductForm;
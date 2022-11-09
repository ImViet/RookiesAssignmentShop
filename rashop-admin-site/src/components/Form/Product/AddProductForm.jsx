import {
  MDBInput,
  MDBBtn,
  MDBValidation,
  MDBValidationItem,
  MDBTextArea,
} from "mdb-react-ui-kit";
import { Form, Col } from "react-bootstrap";
import { useEffect, useState } from "react";
import { getCategorySelect } from "../../../api/Category";
import { getSubCategorySelect } from "../../../api/SubCategory";
function AddProductForm({ onSubmit }) {
  const [product, setProduct] = useState({
    productName: "",
    price: "",
    dateCreated: new Date(),
    dateUpdated: null,
    description: "",
    origin: "",
    unit: "",
    mainImg: "",
    categoryId: "0",
    subCategoryId: null,
  });
  const [categoriesData, setCatesData] = useState();
  const [subCategoriesData, setSubCatesData] = useState();
  useEffect(() => {
    getCategorySelect()
      .then((res) => {
        setCatesData(res);
      })
      .catch((err) => console.log(err));

    getSubCategorySelect()
      .then((res) => {
        setSubCatesData(res);
      })
      .catch((err) => console.log(err));
  }, []);

  function handleSubmit(e) {
    if (product.categoryId === "0") {
      alert("Vui lòng chọn danh mục cha !!!");
    }
    if (
      product.cateName !== "" &&
      product.price !== "" &&
      product.categoryId !== "0" && product.origin !=="" && product.unit !=="" && product.price !== 0
    ) {
      e.preventDefault();
      onSubmit(product);
    } else console.log("Ko hop le");
  }
  const setValues = (e) => {
    setProduct((previousState) => {
      return { ...previousState, [e.target.name]: e.target.value };
    });
  };
  return (
    <MDBValidation onSubmit={handleSubmit} className="row g-3">
      <MDBValidationItem
        tooltip
        feedback="Vui lòng nhập tên"
        invalid
        className="col-md-12"
      >
        <MDBInput
          name="productName"
          id="productName"
          label="Tên sản phẩm"
          size="lg"
          maxLength={250}
          required
          onChange={setValues}
        />
      </MDBValidationItem>
      <MDBValidationItem
        tooltip
        feedback="Vui lòng nhập xuất xứ"
        invalid
        className="col-md-4"
      >
        <MDBInput
          name="origin"
          id="origin"
          label="Xuất xứ"
          size="lg"
          required
          onChange={setValues}
        />
      </MDBValidationItem>
      <MDBValidationItem
        tooltip
        feedback="Vui lòng nhập đơn vị tính"
        invalid
        className="col-md-4"
      >
        <MDBInput
          name="unit"
          id="unit"
          label="Đơn vị tính"
          size="lg"
          required
          onChange={setValues}
        />
      </MDBValidationItem>
      <MDBValidationItem
        tooltip
        feedback="Vui lòng nhập giá"
        invalid
        className="col-md-4"
      >
        <MDBInput
          type="number"
          min="0"
          name="price"
          id="price"
          label="Giá"
          size="lg"
          required
          onChange={setValues}
        />
      </MDBValidationItem>
      <Form.Group as={Col} controlId="formGridState" className="col-md-6">
        <Form.Label>Danh mục cha</Form.Label>
        <Form.Select name="categoryId" onChange={setValues} required>
          <option value="0">Chọn...</option>
          {categoriesData &&
            categoriesData.map((item) => (
              <option key={item.categoryId} value={item.categoryId}>
                {item.categoryName}
              </option>
            ))}
        </Form.Select>
      </Form.Group>
      <Form.Group as={Col} controlId="formGridState" className="col-md-6">
        <Form.Label>Danh mục con</Form.Label>
        <Form.Select name="subCategoryId" onChange={setValues} invalid>
          <option value="0">Chọn...</option>
          {subCategoriesData &&
            subCategoriesData.map((item) => (
              <option key={item.subCategoryId} value={item.subCategoryId}>
                {item.subCategoryName}
              </option>
            ))}
        </Form.Select>
      </Form.Group>
      <MDBValidationItem
        tooltip
        feedback="Vui lòng nhập link ảnh"
        invalid
        className="col-md-12"
      >
        <MDBInput
          name="mainImg"
          id="mainImg"
          label="Link ảnh"
          size="lg"
          onChange={setValues}
        />
      </MDBValidationItem>

      <MDBValidationItem tooltip feedback="Được" invalid className="col-md-12">
        <MDBTextArea
          name="description"
          id="description"
          label="Mô tả"
          size="lg"
          onChange={setValues}
        />
      </MDBValidationItem>

      <div className="col-12">
        <MDBBtn type="submit">Xong</MDBBtn>
      </div>
    </MDBValidation>
  );
}

export default AddProductForm;

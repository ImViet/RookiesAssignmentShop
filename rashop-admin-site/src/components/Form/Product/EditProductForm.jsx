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
import { putProductAPI } from "../../../api/Product";

function EditProductForm({ data, onSubmit }) {
  const [product, setProduct] = useState({
    productId: data.productId,
    productName: data.productName,
    price: data.price,
    dateCreated: data.dateCreated,
    dateUpdated: new Date(),
    description: data.description,
    origin: data.origin,
    unit: data.unit,
    mainImg: data.mainImg,
    categoryId: data.categoryId,
    subCategoryId: data.subCategoryId,
  });
  const [categoriesData, setCatesData] = useState();
  const [subCategoriesData, setSubCatesData] = useState();
  useEffect(() => {
    getCategorySelect()
      .then((res) => {
        setCatesData(res);
      })
      .catch((err) => console.log(err));
  }, []);
  useEffect(() => {
    getSubCategorySelect()
      .then((res) => {
        setSubCatesData(res);
      })
      .catch((err) => console.log(err));
  }, []);
  const setValues = (e) => {
    setProduct((previousState) => {
      return { ...previousState, [e.target.name]: e.target.value };
    });
  };
  function handleSubmit(e) {
    if (product.cateName !== "" && product.price !=="" && product.categoryId !== "") {
      e.preventDefault();
      console.log(product);
      putProductAPI(product);
      onSubmit(product);
    } else console.log("Ko hop le");
  }
  return (
    <MDBValidation onSubmit={handleSubmit} className="row g-3">
      <MDBValidationItem tooltip className="col-md-12">
        <MDBInput
          name="productId"
          id="productId"
          label="Id"
          required
          disabled
          defaultValue={data.productId}
          onChange={setValues}
        />
      </MDBValidationItem>
      <MDBValidationItem tooltip invalid className="col-md-6">
        <MDBInput
          name="dateCreated"
          id="dateCreated"
          label="Ngày tạo"
          required
          disabled
          defaultValue={data.dateCreated}
          onChange={setValues}
        />
      </MDBValidationItem>
      <MDBValidationItem tooltip invalid className="col-md-6">
        <MDBInput
          name="dateUpdated"
          id="dateUpdated"
          label="Ngày cập nhật"
          required
          disabled
          defaultValue={
            data.dateUpdated !== null ? data.dateUpdated : "Chưa cập nhật"
          }
          onChange={setValues}
        />
      </MDBValidationItem>
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
          required
          defaultValue={data.productName}
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
          required
          defaultValue={data.origin}
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
          required
          defaultValue={data.unit}
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
          name="price"
          id="price"
          label="Giá"
          required
          defaultValue={data.price}
          onChange={setValues}
        />
      </MDBValidationItem>
      <Form.Group as={Col} controlId="formGridState" className="col-md-6">
        <Form.Label>Danh mục cha</Form.Label>
        <Form.Select
          defaultValue={data.categoryId}
          name="categoryId"
          onChange={setValues}
        >
          <option>Hiện tại thuộc: {data.categoryName}</option>
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
        <Form.Select
          defaultValue={data.subCategoryId}
          name="subCategoryId"
          onChange={setValues}
          invalid
        >
          <option>Hiện tại thuộc: {data.subCategoryName}</option>
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
          defaultValue={data.mainImg}
          onChange={setValues}
        />
      </MDBValidationItem>

      <MDBValidationItem
        tooltip
        invalid
        className="col-md-12"
      >
        <MDBTextArea
          name="description"
          id="description"
          label="Mô tả"
          defaultValue={data.description}
          onChange={setValues}
        />
      </MDBValidationItem>

      <div className="col-12">
        <MDBBtn type="submit">Xong</MDBBtn>
      </div>
    </MDBValidation>
  );
}
export default EditProductForm;

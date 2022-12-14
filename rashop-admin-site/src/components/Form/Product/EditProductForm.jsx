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

function EditProductForm({ data, onSubmit }) {
  const [product, setProduct] = useState({
    productId: data.productId,
    productName: data.productName,
    price: data.price,
    dateCreated: data.dateCreated,
    // dateUpdated: new Date(),
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
    if(product.subCategoryId === "") product.subCategoryId = null;
    if (product.productName !== "" && product.price !=="" && product.categoryId !== "0" &&
        product.origin !=="" && product.unit !=="" && product.price !== 0) {
      e.preventDefault();
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
          size="lg"
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
          label="Ng??y t???o"
          size="lg"
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
          label="Ng??y c???p nh???t"
          size="lg"
          required
          disabled
          defaultValue={
            data.dateUpdated !== null ? data.dateUpdated : "Ch??a c???p nh???t"
          }
          onChange={setValues}
        />
      </MDBValidationItem>
      <MDBValidationItem
        tooltip
        feedback="Vui l??ng nh???p t??n"
        invalid
        className="col-md-12"
      >
        <MDBInput
          name="productName"
          id="productName"
          label="T??n s???n ph???m"
          size="lg"
          maxLength={250}
          required
          defaultValue={data.productName}
          onChange={setValues}
        />
      </MDBValidationItem>
      <MDBValidationItem
        tooltip
        feedback="Vui l??ng nh???p xu???t x???"
        invalid
        className="col-md-4"
      >
        <MDBInput
          name="origin"
          id="origin"
          label="Xu???t x???"
          size="lg"
          required
          defaultValue={data.origin}
          onChange={setValues}
        />
      </MDBValidationItem>
      <MDBValidationItem
        tooltip
        feedback="Vui l??ng nh???p ????n v??? t??nh"
        invalid
        className="col-md-4"
      >
        <MDBInput
          name="unit"
          id="unit"
          label="????n v??? t??nh"
          size="lg"
          required
          defaultValue={data.unit}
          onChange={setValues}
        />
      </MDBValidationItem>
      <MDBValidationItem
        tooltip
        feedback="Vui l??ng nh???p gi??"
        invalid
        className="col-md-4"
      >
        <MDBInput
          name="price"
          id="price"
          label="Gi??"
          size="lg"
          required
          defaultValue={data.price}
          onChange={setValues}
        />
      </MDBValidationItem>
      <Form.Group as={Col} controlId="formGridState" className="col-md-6">
        <Form.Label>Danh m???c cha</Form.Label>
        <Form.Select
          defaultValue={data.categoryId}
          name="categoryId"
          onChange={setValues}
        >
          <option value={data.categoryId}>Hi???n t???i thu???c: {data.categoryName}</option>
          {categoriesData &&
            categoriesData.map((item) => (
              <option key={item.categoryId} value={item.categoryId}>
                {item.categoryName}
              </option>
            ))}
        </Form.Select>
      </Form.Group>
      <Form.Group as={Col} controlId="formGridState" className="col-md-6">
        <Form.Label>Danh m???c con</Form.Label>
        <Form.Select
          defaultValue={data.subCategoryId}
          name="subCategoryId"
          onChange={setValues}
          invalid
        >
          {data.subCategoryId !== null ? <option value={data.subCategoryId} disabled>Hi???n t???i thu???c: {data.subCategoryName}</option> : <option value={null} disabled>Kh??ng</option>}
          <option value = "">Kh??ng</option>
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
        feedback="Vui l??ng nh???p link ???nh"
        className="col-md-12"
        size="lg"
        invalid
      >
        <MDBInput
          name="mainImg"
          id="mainImg"
          label="Link ???nh"
          size="lg"
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
          label="M?? t???"
          size="lg"
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

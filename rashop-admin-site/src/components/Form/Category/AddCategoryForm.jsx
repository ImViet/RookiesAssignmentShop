import { useState } from "react";
import {
  MDBValidation,
  MDBValidationItem,
  MDBInput,
  MDBBtn,
  MDBTextArea,
} from "mdb-react-ui-kit";
function AddCategoryForm({ onSubmit }) {
  const [cate, setCate] = useState({
    cateName: "",
    description: "",
    image: "",
  });
  function handleSubmit(e) {
    if (cate.cateName !== "") {
      e.preventDefault();
      onSubmit(cate);
    } else console.log("Ko hop le");
  }
  const setValues = (e) => {
    setCate((previousState) => {
      return { ...previousState, [e.target.name]: e.target.value };
    });
  };

  return (
    <MDBValidation onSubmit={handleSubmit} className="row g-3">
      <MDBValidationItem tooltip feedback="Vui lòng nhập tên danh mục" invalid className="col-md-12">
        <MDBInput
          onChange={setValues}
          name="cateName"
          id="cateName"
          size="lg"
          label="Tên danh mục"
          maxLength={50}
          required
        />
      </MDBValidationItem>
      <MDBValidationItem tooltip feedback="Được" className="col-md-12">
        <MDBTextArea
          onChange={setValues}
          name="description"
          id="description"
          label="Mô tả"
          size="lg"
        />
      </MDBValidationItem>
      <div className="col-12">
        <MDBBtn type="submit">Xong</MDBBtn>
      </div>
    </MDBValidation>
  );
}
export default AddCategoryForm;

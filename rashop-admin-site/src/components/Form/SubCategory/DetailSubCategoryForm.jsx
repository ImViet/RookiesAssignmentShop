import { Button, Form } from "react-bootstrap";
import {
  MDBValidation,
  MDBValidationItem,
  MDBInput,
  MDBBtn,
  MDBTextArea,
} from "mdb-react-ui-kit";
function DetailSubCategoryForm({ data }) {
  return (
    <MDBValidation className="row g-3">
      <MDBValidationItem className="col-md-12">
        <MDBInput
          name="subCateId"
          id="subCateId"
          size="lg"
          label="Id"
          defaultValue={data.subCategoryId}
          required
        />
      </MDBValidationItem>
      <MDBValidationItem className="col-md-12">
        <MDBInput
          name="subCateName"
          id="subCateName"
          size="lg"
          label="Tên danh mục con"
          defaultValue={data.subCategoryName}
          required
        />
      </MDBValidationItem>

      <MDBValidationItem className="col-md-12 ">
        <MDBTextArea
          name="description"
          id="description"
          label="Mô tả"
          size="lg"
          defaultValue={data.description}
        />
      </MDBValidationItem>
      <MDBValidationItem className="col-md-12">
        <MDBInput
          name="cateName"
          id="cateName"
          size="lg"
          label="Thuộc danh mục"
          defaultValue={data.categoryParentName}
          required
        />
      </MDBValidationItem>
    </MDBValidation>
  );
}
export default DetailSubCategoryForm;

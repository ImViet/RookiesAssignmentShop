import {
  MDBInput,
  MDBBtn,
  MDBValidation,
  MDBValidationItem,
  MDBTextArea,
} from "mdb-react-ui-kit";
function DetailProductForm({data}) {
  return (
    <MDBValidation className="row g-3">
      <MDBValidationItem tooltip className="col-md-12">
        <MDBInput
          name="productId"
          id="productId"
          label="Id"
          size="lg"
          required
          disabled
          defaultValue={data.productId}
        />
      </MDBValidationItem>
      <MDBValidationItem tooltip invalid className="col-md-6">
        <MDBInput
          name="dateCreated"
          id="dateCreated"
          label="Ngày tạo"
          size="lg"
          required
          disabled
          defaultValue={data.dateCreated}
        />
      </MDBValidationItem>
      <MDBValidationItem tooltip invalid className="col-md-6">
        <MDBInput
          name="dateUpdated"
          id="dateUpdated"
          label="Ngày cập nhật"
          size="lg"
          required
          disabled
          defaultValue={
            data.dateUpdated !== null ? data.dateUpdated : "Chưa cập nhật"
          }
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
          size="lg"
          required
          defaultValue={data.productName}
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
          defaultValue={data.origin}
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
          defaultValue={data.unit}
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
          size="lg"
          required
          defaultValue={data.price}
        />
      </MDBValidationItem>
      <MDBValidationItem
        tooltip
        invalid
        className="col-md-6"
      >
        <MDBInput
          name="categoryName"
          id="categoryName"
          label="Danh mục cha"
          size="lg"
          required
          defaultValue={data.categoryName !== null ? data.categoryName : "Không"}
        />
      </MDBValidationItem>
      <MDBValidationItem
        tooltip
        invalid
        className="col-md-6"
      >
        <MDBInput
          name="subCategoryName"
          id="subCategoryName"
          label="Danh mục con"
          size="lg"
          required
          defaultValue={data.subCategoryName !== null ? data.subCategoryName : "Không"}
        />
      </MDBValidationItem>
      <MDBValidationItem
        tooltip
        invalid
        className="col-md-12"
      >
        {/* <MDBInput
          name="mainImg"
          id="mainImg"
          label="Link ảnh"
          size="lg"
          defaultValue={data.mainImg !== "" ? data.mainImg : "Chưa cập nhật"}
        /> */}
        <img className='img-fluid mx-auto d-block rounded w-50' src={data.mainImg} alt={data.productName} />
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
          size="lg"
          defaultValue={data.description}
        />
      </MDBValidationItem>
    </MDBValidation>
  );
}

export default DetailProductForm;

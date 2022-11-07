import React, { useEffect, useState } from "react";
import {
  Button,
  InputGroup,
  Form,
  Dropdown,
  DropdownButton,
  Row,
  Col,
} from "react-bootstrap";
import {
  MDBBtn,
  MDBTable,
  MDBTableHead,
  MDBTableBody,
  MDBInput,
} from "mdb-react-ui-kit";
import { getSubCategoryAPI } from "../../api/SubCategory";
import AddSubCategoryModal from "../../components/Modal/SubCategory/AddSubCategoryModal";
import EditSubCategoryModal from "../../components/Modal/SubCategory/EditSubCategoryModal";
import DeleteSubCategoryModal from "../../components/Modal/SubCategory/DeleteSubCategoryModal";
import DetailSubCategoryModal from "../../components/Modal/SubCategory/DetailSubCategoryModal";
function Category() {
  const [categoriesData, setCatesData] = useState();
  const [sort, setSort] = useState("0");
  const [query, setQuery] = useState("");
  const [pageIndex, setPageIndex] = useState(1);
  const [showAddModal, setShowAddModal] = useState(false);
  const [showEditModal, setShowEditModal] = useState(false);
  const [showDeleteModal, setShowDeleteModal] = useState(false);
  const [showDetailModal, setShowDetailModal] = useState(false);
  const [current, setCurrent] = useState();
  useEffect(() => {
    getSubCategoryAPI(query, pageIndex, sort)
      .then((res) => {
        setCatesData(res);
      })
      .catch((err) => console.log(err));
  }, [query, pageIndex, sort, showAddModal, showEditModal, showDeleteModal]);

  //Start: Function handle pagination
  function handleNextPage() {
    if (pageIndex < categoriesData.totalPages) {
      setPageIndex((i) => i + 1);
    }
  }
  function handlePrePage() {
    if (pageIndex > 1) {
      setPageIndex((i) => i - 1);
    }
  }
  //End: Function handle pagination

  //Start: Function handle click to call modal
  function handleShowAddModal() {
    setShowAddModal(true);
  }
  //End: Function handle click to call modal
  return (
    <React.Fragment>
        <Row className="mt-3 mb-2">
        <MDBInput
          className="mt-1 mb-0"
          label="Tìm kiếm"
          id="search"
          type="text"
          onChange={(e) => {
            setQuery(e.target.value);
            setPageIndex((i) => (i = 1));
          }}
        />
      </Row>
      <Row>
        <Col>
          <DropdownButton
            variant="secondary"
            id="dropdown-item-button"
            title="Sắp xếp"
          >
            <Dropdown.Item
              as="button"
              onClick={() => {
                setSort((s) => "name");
                setPageIndex((i) => (i = 1));
              }}
            >
              Tên a-z
            </Dropdown.Item>
            <Dropdown.Item
              as="button"
              onClick={() => {
                setSort((s) => "name_desc");
                setPageIndex((i) => (i = 1));
              }}
            >
              Tên z-a
            </Dropdown.Item>
          </DropdownButton>
        </Col>
        <Col>
          <Button onClick={() => setShowAddModal(true)} variant="success">
            Tạo mới
          </Button>
        </Col>
      </Row>

      <MDBTable align="middle" className="mt-4" responsive="md">
        <MDBTableHead>
          <tr className="table-danger">
            <th scope="col">ID</th>
            <th scope="col">Danh Mục</th>
            <th scope="col"></th>
          </tr>
        </MDBTableHead>
        <MDBTableBody>
          {categoriesData &&
            categoriesData.items.map((item) => (
              <tr>
                <th scope="row">{item.subCategoryId}</th>
                <td>{item.subCategoryName}</td>
                <td>
                  <MDBBtn
                    outline
                    rounded
                    className="mx-1"
                    color="info"
                    onClick={() => {
                      setCurrent(item);
                      setShowDetailModal(true);
                    }}
                  >
                    Chi tiết
                  </MDBBtn>
                  <MDBBtn
                    outline
                    rounded
                    className="mx-1"
                    color="warning"
                    onClick={() => {
                      setCurrent(item);
                      setShowEditModal(true);
                    }}
                  >
                    Sửa
                  </MDBBtn>
                  <MDBBtn
                    outline
                    rounded
                    className="mx-1"
                    color="danger"
                    onClick={() => {
                      setCurrent(item);
                      setShowDeleteModal(true);
                    }}
                  >
                    Xóa
                  </MDBBtn>
                </td>
              </tr>
            ))}
        </MDBTableBody>
      </MDBTable>
      <Col className="mb-3">
        <MDBBtn
          className="me-2"
          color="light"
          rippleColor="dark"
          onClick={handlePrePage}
        >
          Trước
        </MDBBtn>
        <MDBBtn color="light" rippleColor="dark" onClick={handleNextPage}>
          Sau
        </MDBBtn>
      </Col>
      {/* Add sub category modal */}
      <AddSubCategoryModal
        status={showAddModal}
        onClose={() => setShowAddModal(false)}
      />
      {/* Edit sub category modal */}
      <EditSubCategoryModal
        status={showEditModal}
        data={current}
        onClose={() => setShowEditModal(false)}
      />
      {/* Delete sub category modal */}
      <DeleteSubCategoryModal
        status={showDeleteModal}
        data={current}
        onClose={() => setShowDeleteModal(false)}
      />
      {/* Detail sub category modal  */}
      <DetailSubCategoryModal
        status={showDetailModal}
        data={current}
        onClose={() => setShowDetailModal(false)}
      />
    </React.Fragment>
  );
}

export default Category;

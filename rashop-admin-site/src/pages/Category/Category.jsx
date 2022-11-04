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
import { getCategoryAPI } from "../../api/Category";
import AddCategoryModal from "../../components/Modal/Category/AddCategoryModal";
import EditCategoryModal from "../../components/Modal/Category/EditCategoryModal";
import DeleteCategoryModal from "../../components/Modal/Category/DeleteCategoryModal";
function Category() {
  const [categoriesData, setCatesData] = useState();
  const [sort, setSort] = useState("0");
  const [query, setQuery] = useState("");
  const [pageIndex, setPageIndex] = useState(1);
  const [showAddModal, setShowAddModal] = useState(false);
  const [showEditModal, setShowEditModal] = useState(false);
  const [showDeleteModal, setShowDeleteModal] = useState(false);
  const [current, setCurrent] = useState();
  useEffect(() => {
    getCategoryAPI(query, pageIndex, sort)
      .then((res) => {
        setCatesData(res);
      })
      .catch((err) => console.log(err));
  }, [query, pageIndex, sort]);

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
      <InputGroup className="mb-3">
        <Form.Control
          placeholder="Nhập để tìm kiếm..."
          aria-label="Recipient's username"
          aria-describedby="basic-addon2"
          onChange={(e) => {
            setQuery(e.target.value);
            setPageIndex((i) => (i = 1));
          }}
        />
      </InputGroup>
      <Row>
        <Col>
          <DropdownButton
            variant="secondary"
            id="dropdown-item-button"
            title="Sắp xếp"
          >
            <Dropdown.Item as="button" onClick={() => setSort((s) => "name")}>
              Tên a-z
            </Dropdown.Item>
            <Dropdown.Item
              as="button"
              onClick={() => setSort((s) => "name_desc")}
            >
              Tên z-a
            </Dropdown.Item>
          </DropdownButton>
        </Col>
        <Col>
          <Button onClick={handleShowAddModal} variant="success">
            Tạo mới
          </Button>
        </Col>
      </Row>

      <table className="table table-striped table-hover table-boredered">
        <thead>
          <tr>
            <th scope="col">Id</th>
            <th scope="col">Danh mục</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {categoriesData &&
            categoriesData.items.map((item) => (
              <tr key={item.categoryId}>
                <td>{item.categoryId}</td>
                <td>{item.categoryName}</td>
                <td>
                  <Button variant="outline-primary">Chi tiết</Button>
                  <Button
                    variant="outline-warning"
                    onClick={() => {
                      setCurrent(item);
                      setShowEditModal(true);
                    }}
                  >
                    Sửa
                  </Button>
                  <Button  onClick={() => {
                      setCurrent(item);
                      setShowDeleteModal(true);
                    }} variant="outline-danger">Xóa</Button>
                </td>
              </tr>
            ))}
        </tbody>
        <Button variant="outline-secondary" onClick={handlePrePage}>
          Trước
        </Button>
        <Button variant="outline-secondary" onClick={handleNextPage}>
          Sau
        </Button>
      </table>
      {/* Add category modal */}
      <AddCategoryModal
        status={showAddModal}
        onClose={() => setShowAddModal(false)}
      />
      {/* Edit category modal */}
      <EditCategoryModal
        status={showEditModal}
        data={current}
        onClose={() => setShowEditModal(false)}
      />
      {/* Delete category modal */}
      <DeleteCategoryModal
        status={showDeleteModal}
        data={current}
        onClose={() => setShowDeleteModal(false)}
      />
    </React.Fragment>
  );
}

export default Category;

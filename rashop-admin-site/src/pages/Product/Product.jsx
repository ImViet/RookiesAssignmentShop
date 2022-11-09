import React, { useEffect, useState } from "react";
import {
  Button,
  InputGroup,
  Form,
  Dropdown,
  DropdownButton,
  Col,
  Row,
} from "react-bootstrap";
import {
  MDBBtn,
  MDBTable,
  MDBTableHead,
  MDBTableBody,
  MDBInput,
} from "mdb-react-ui-kit";
import { getProductAPI } from "../../api/Product";
import AddProductModal from "../../components/Modal/Product/AddProductModal";
import DetailProductModal from "../../components/Modal/Product/DetailProductModal";
import EditProductModal from "../../components/Modal/Product/EditProductModal";
import DeleteProductModal from "../../components/Modal/Product/DeleteProductModal";
function Product() {
  const [productsData, setProductsData] = useState();
  const [sort, setSort] = useState("0");
  const [query, setQuery] = useState("");
  const [pageIndex, setPageIndex] = useState(1);
  const [showDetailModal, setShowDetailModal] = useState(false);
  const [showAddModal, setShowAddModal] = useState(false);
  const [showEditModal, setShowEditModal] = useState(false);
  const [showDeleteModal, setShowDeleteModal] = useState(false);
  const [current, setCurrent] = useState();
  useEffect(() => {
    getProductAPI(query, pageIndex, sort)
      .then((res) => {
        setProductsData(res);
        console.log("re-render");
      })
      .catch((err) => console.log(err));
  }, [query, pageIndex, sort, productsData]);

  //Start: Function handle pagination
  function handleNextPage() {
    if (pageIndex < productsData.totalPages) {
      setPageIndex((i) => i + 1);
    }
  }
  function handlePrePage() {
    if (pageIndex > 1) {
      setPageIndex((i) => i - 1);
    }
  }
  //End: Function handle pagination
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
              onClick={() => {
                setSort((s) => "price");
                setPageIndex((i) => (i = 1));
              }}
            >
              Giá tăng dần
            </Dropdown.Item>
            <Dropdown.Item
              as="button"
              onClick={() => {
                setSort((s) => "price_desc");
                setPageIndex((i) => (i = 1));
              }}
            >
              Giá giảm dần
            </Dropdown.Item>
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
      {/* Add Product Modal  */}
      <AddProductModal
        status={showAddModal}
        onClose={() => setShowAddModal(false)}
      />
      {/* Detail Product Modal */}
      <DetailProductModal
        status={showDetailModal}
        data={current}
        onClose={() => setShowDetailModal(false)}
      />
      {/* Edit Product Modal */}
      <EditProductModal
        status={showEditModal}
        data={current}
        onClose={() => setShowEditModal(false)}
      />
      {/* Delete Product Modal */}
      <DeleteProductModal
        status={showDeleteModal}
        data={current}
        onClose={() => setShowDeleteModal(false)}
      />
      <MDBTable align="middle" className="mt-4" responsive="md">
        <MDBTableHead>
          <tr className="table-danger">
            <th scope="col">ID</th>
            <th scope="col">Sản phẩm</th>
            <th scope="col">Giá & ĐVT</th>
            <th scope="col">Xuất xứ</th>
            <th scope="col"></th>
          </tr>
        </MDBTableHead>
        <MDBTableBody>
          {productsData &&
            productsData.items.map((item) => (
              <tr>
                <td>{item.productId}</td>
                <td>
                  <div className="d-flex align-items-center">
                    <img
                      src= {item.mainImg}
                      alt=""
                      style={{ width: "60px", height: "60px" }}
                      className="rounded-circle"
                    />
                    <div className="ms-4">
                      <p className="fw-bold mb-1">{item.productName}</p>
                      <p className="text-muted mb-0">{item.categoryName}</p>
                    </div>
                  </div>
                </td>
                <td>
                  <p className="fw-normal mb-1">{item.price}</p>
                  <p className="text-muted mb-0">{item.unit}</p>
                </td>
                <td>{item.origin}</td>
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
    </React.Fragment>
  );
}

export default Product;

import React, { useEffect, useState } from "react";
import { Button, InputGroup, Form, Dropdown, DropdownButton } from "react-bootstrap";
import { getCategoryAPI } from "../../api/Category";
function Category() {
  const [categoriesData, setCatesData] = useState();
  const [sort, setSort] = useState("0");
  const [query, setQuery] = useState("");
  const [pageIndex, setPageIndex] = useState(1);
  useEffect(() => {
    getCategoryAPI(query, pageIndex, sort )
      .then((res) => {
        setCatesData(res);
      })
      .catch((err) => console.log(err));
  }, [query,pageIndex, sort]);
  function handleNextPage(){
    if(pageIndex < categoriesData.totalPages){
      setPageIndex((i) => (i + 1))
    }
  }
  function handlePrePage(){
    if(pageIndex > 1){
      setPageIndex((i) => (i - 1))
    }
  }
  return (
    <React.Fragment>
        <InputGroup className="mb-3">
        <Form.Control
          placeholder="Nhập để tìm kiếm..."
          aria-label="Recipient's username"
          aria-describedby="basic-addon2"
          onChange={(e) =>{ setQuery(e.target.value) ; setPageIndex((i) => i =1)}}
        />
      </InputGroup>
      <DropdownButton
        variant="secondary"
        id="dropdown-item-button"
        title="Sắp xếp"
      >
        <Dropdown.Item as="button" onClick={() => setSort((s) => "name")}>
          Tên a-z
        </Dropdown.Item>
        <Dropdown.Item as="button" onClick={() => setSort((s) => "name_desc")}>
          Tên z-a
        </Dropdown.Item>
      </DropdownButton>
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
                  <Button variant="outline-warning">Sửa</Button>
                  <Button variant="outline-danger">Xóa</Button>
                </td>
              </tr>
            ))}
        </tbody>
        <Button
          variant="outline-secondary"
          onClick={handlePrePage}
        >
          Trước
        </Button>
        <Button
          variant="outline-secondary"
          onClick={handleNextPage}
        >
          Sau
        </Button>
      </table>
    </React.Fragment>
  );
}

export default Category;

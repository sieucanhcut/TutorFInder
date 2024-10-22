import React from 'react';
import {
  CDBSidebar,
  CDBSidebarContent,
  CDBSidebarHeader,
  CDBSidebarMenu,
  CDBSidebarMenuItem,
  CDBSidebarFooter,
} from 'cdbreact';
import { Link } from 'react-router-dom';

export const Sidebar = () => {
  return (
      <CDBSidebar>
        <CDBSidebarHeader prefix={<i className="fa fa-bars" />}></CDBSidebarHeader>
        <CDBSidebarContent>
          <CDBSidebarMenu>
            <CDBSidebarMenuItem icon="th-large">
              <Link to="/admin/dashboard">Dashboard</Link>
            </CDBSidebarMenuItem>
            <CDBSidebarMenuItem icon="sticky-note">
              <Link to="/admin/account">tài khoản</Link>
            </CDBSidebarMenuItem>
            <CDBSidebarMenuItem icon="newspaper" iconType="solid">
              <Link to="/admin/news">tin tức</Link>
            </CDBSidebarMenuItem>
            <CDBSidebarMenuItem icon="credit-card" iconType="solid">
              <Link to="/admin/paymentmanager">Thanh toán<nav></nav></Link>
            </CDBSidebarMenuItem>
            <CDBSidebarMenuItem icon="file-alt" iconType="solid">
              <Link to="/admin/CVs">CVs</Link>
            </CDBSidebarMenuItem>

          </CDBSidebarMenu>
        </CDBSidebarContent>
        <CDBSidebarFooter style={{ textAlign: 'center' }}>

        </CDBSidebarFooter>
      </CDBSidebar>
  );
};

export default Sidebar;

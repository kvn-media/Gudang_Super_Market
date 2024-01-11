﻿using Gudang_Super_Market.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Gudang> Gudangs { get; set; }
    public DbSet<Barang> Barangs { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Konfigurasi untuk tabel Barang
        modelBuilder.Entity<Barang>()
            .Property(b => b.NamaBarang)
            .HasMaxLength(100) // Misalnya, batasan panjang maksimum
            .IsRequired(); // NamaBarang wajib diisi

        modelBuilder.Entity<Barang>()
            .Property(b => b.HargaBarang)
            .HasColumnType("decimal(18,2)"); // Menentukan tipe data dan presisi untuk harga

        // Menambahkan indeks ke kolom NamaBarang pada tabel Barang
        modelBuilder.Entity<Barang>()
            .HasIndex(b => b.NamaBarang)
            .IsUnique();

        // Konfigurasi untuk tabel Gudang
        modelBuilder.Entity<Gudang>()
            .Property(g => g.NamaGudang)
            .HasMaxLength(50) // Misalnya, batasan panjang maksimum
            .IsRequired(); // NamaGudang wajib diisi

        // Konfigurasi lainnya sesuai kebutuhan Anda...

        base.OnModelCreating(modelBuilder);
    }
}